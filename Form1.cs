using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiraDemo
{
    public partial class Form1 : Form
    {
        private readonly string baseUrl = "https://YOURJIRADOMAIN.atlassian.net/rest/api/3";
        string email = string.Empty;
        string apikey = string.Empty;
        string basicAuth = string.Empty;
        List<IssueModel> EpicList = new List<IssueModel>();
        List<IssueModel> StoryList = new List<IssueModel>();
        List<IssueModel> TaskList = new List<IssueModel>();
        List<IssueModel> SubtaskList = new List<IssueModel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //example project name
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //you can get these parameters from app ui
            email = "YOUR_EMAIL";
            apikey = "YOUR_TOKEN";

            SetToken();
            GetIssueListByProject(textBox1.Text);
        }

        public void GetIssueListByProject(string project)
        {
            var maxCount = 0;
            var totalCount = 10;
            var issueList = new List<Issue>();

            //Jira allows you max 100 record per request so we need this while section to get all record from
            while (maxCount < totalCount)
            {
                var client = new RestClient(baseUrl + "/search?jql=project=" + project + "&maxResults=10&startAt=" + maxCount);
                var request = new RestRequest
                {
                    Method = Method.GET,
                    RequestFormat = DataFormat.Json
                };


                request.AddHeader("Authorization", "Basic " + basicAuth);
                var response = client.Execute(request);
                var result = response.Content;
                var issueResponse = JsonConvert.DeserializeObject<IssueResponse>(result);
                issueList.AddRange(issueResponse.issues);
                totalCount = issueResponse.total;
                maxCount = maxCount + 10;
            }

            #region epic
            //epic is the 1. level of jira hierarchy
            var epicList = issueList.Where(x => x.fields.issuetype.name == "Epic").ToList();

            foreach (var epic in epicList)
            {
                var newModel = new IssueModel();
                newModel.Id = epic.id;
                newModel.Key = epic.key;
                newModel.Self = epic.self;
                newModel.Description = epic.fields.issuetype.description;
                newModel.ProjectName = project;
                newModel.Release = epic.fields.fixVersions[0].name;
                newModel.IssueType = epic.fields.issuetype.name;
                newModel.EpicId = 0;
                newModel.EpicTitle = "-";
                newModel.StoryId = 0;
                newModel.StoryTitle = "-";
                newModel.TaskId = 0;
                newModel.TaskTitle = "-";
                newModel.SubtaskId = 0;
                newModel.SubtaskTitle = "-";
                newModel.AssignedTo = "-";
                newModel.OriginalEstimate = 0;
                newModel.TimeLogged = 0;

                EpicList.Add(newModel);
            }
            #endregion

            #region story
            //story is 2. hierarchy, below epic. 
            var storyList = issueList.Where(x => x.fields.issuetype.name == "Story").ToList();

            foreach (var story in storyList)
            {
                var newModel = new IssueModel();
                newModel.Id = story.id;
                newModel.Key = story.key;
                newModel.Self = story.self;
                newModel.Description = story.fields.issuetype.description;
                newModel.ProjectName = project;
                newModel.Release = SetRelease(story);
                newModel.IssueType = story.fields.issuetype.name;
                newModel.EpicId = SetEpic(story).Id;
                newModel.EpicTitle = EpicList.FirstOrDefault(x => x.Id == newModel.EpicId).Description;
                newModel.StoryId = 0;
                newModel.StoryTitle = "-";
                newModel.TaskId = 0;
                newModel.TaskTitle = "-";
                newModel.SubtaskId = 0;
                newModel.SubtaskTitle = "-";
                newModel.AssignedTo = "-";
                newModel.OriginalEstimate = 0;
                newModel.TimeLogged = 0;

                StoryList.Add(newModel);
            }
            #endregion

            #region task
            //task is 3. hierarchy but not always belongs to story, sometimes belongs to epic so that we create SetEpic and SetStory methods below
            var taskList = issueList.Where(x => x.fields.issuetype.name == "Task").ToList();

            foreach (var task in taskList)
            {
                var newModel = new IssueModel();
                newModel.Id = task.id;
                newModel.Key = task.key;
                newModel.Self = task.self;
                newModel.Description = task.fields.issuetype.description;
                newModel.ProjectName = project;
                newModel.Release = SetRelease(task);
                newModel.IssueType = task.fields.issuetype.name;
                newModel.EpicId = SetEpic(task)?.Id;
                newModel.EpicTitle = EpicList.FirstOrDefault(x => x.Id == newModel.EpicId)?.Description;
                newModel.StoryId = SetStory(task)?.Id;
                newModel.StoryTitle = StoryList.FirstOrDefault(x => x.Id == SetStory(task).Id)?.Description;
                newModel.TaskId = task.id;
                newModel.TaskTitle = task.fields.summary;
                newModel.SubtaskId = 0;
                newModel.SubtaskTitle = "-";
                newModel.AssignedTo = SetAssignee(task);
                newModel.OriginalEstimate = task.fields.timeoriginalestimate ?? 0;
                newModel.TimeLogged = Convert.ToInt32(task.fields.aggregatetimespent) / 60;

                TaskList.Add(newModel);
            }
            #endregion

            #region subtask
            //lowest level of hierarchy
            var subtaskList = issueList.Where(x => x.fields.issuetype.name == "Subtask").ToList();

            foreach (var subtask in subtaskList)
            {
                var newModel = new IssueModel();
                newModel.Id = subtask.id;
                newModel.Key = subtask.key;
                newModel.Self = subtask.self;
                newModel.Description = subtask.fields.issuetype.description;
                newModel.ProjectName = project;
                newModel.Release = SetRelease(subtask);
                newModel.IssueType = subtask.fields.issuetype.name;
                newModel.EpicId = SetEpic(subtask).Id;
                newModel.EpicTitle = EpicList.FirstOrDefault(x => x.Id == newModel.EpicId).Description;
                newModel.StoryId = SetStory(subtask).Id;
                newModel.StoryTitle = StoryList.FirstOrDefault(x => x.Id == SetStory(subtask).Id)?.Description;
                newModel.TaskId = subtask.id;
                newModel.TaskTitle = subtask.fields.summary;
                newModel.SubtaskId = 0;
                newModel.SubtaskTitle = subtask.fields.summary;
                newModel.AssignedTo = SetAssignee(subtask);
                newModel.OriginalEstimate = subtask.fields.timeoriginalestimate ?? 0;
                newModel.TimeLogged = Convert.ToInt32(subtask.fields.aggregatetimespent) / 60;

                SubtaskList.Add(newModel);
            }
            #endregion

            var resultList = new List<IssueModel>();
            resultList.AddRange(EpicList);
            resultList.AddRange(StoryList);
            resultList.AddRange(TaskList);
            resultList.AddRange(SubtaskList);

            var jsonresult = JsonConvert.SerializeObject(resultList);
        }

        public string SetAssignee(Issue issue)
        {
            var assisgnee = string.Empty;

            if (issue.fields.assignee != null && !string.IsNullOrEmpty(issue.fields.assignee.displayName))
            {
                assisgnee = issue.fields.assignee.displayName;
            }

            return assisgnee;
        }

        public IssueModel SetStory(Issue issue)
        {
            var story = new IssueModel();
            var type = issue.fields.issuetype.name;

            if (type == "Task")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Story")
                {
                    story = StoryList.FirstOrDefault(y => y.Id == issue.fields.parent.id);
                }
            }
            else if (type == "Subtask")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Story")
                {
                    story = StoryList.FirstOrDefault(y => y.Id == issue.fields.parent.id);
                }
                else if (parentType == "Task")
                {
                    story = StoryList.FirstOrDefault(x => x.Id == TaskList.FirstOrDefault(y => y.Id == issue.fields.parent.id)?.StoryId) ?? new IssueModel();
                }
            }

            return story;
        }

        public IssueModel SetEpic(Issue issue)
        {
            var epic = new IssueModel();
            var type = issue.fields.issuetype.name;

            if (type == "Story")
            {
                epic = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id);
            }
            else if (type == "Task")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Epic")
                {
                    epic = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id);
                }
                else if (parentType == "Story")
                {
                    epic = EpicList.FirstOrDefault(x => x.Id == StoryList.FirstOrDefault(y => y.Id == issue.fields.parent.id).Id);
                }
            }
            else if (type == "Subtask")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Epic")
                {
                    epic = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id);
                }
                else if (parentType == "Story")
                {
                    epic = EpicList.FirstOrDefault(x => x.Id == StoryList.FirstOrDefault(y => y.Id == issue.fields.parent.id).EpicId);
                }
                else if (parentType == "Task")
                {
                    epic = EpicList.FirstOrDefault(x => x.Id == TaskList.FirstOrDefault(y => y.Id == issue.fields.parent.id).EpicId);
                }
            }

            return epic;
        }

        public string SetRelease(Issue issue)
        {
            var release = string.Empty;
            var type = string.Empty;

            if (issue.fields.parent == null && issue.fields.issuetype.name == "Epic")
            {
                type = "Epic";
            }
            else
            {
                type = issue.fields.issuetype.name;
            }

            if (type == "Epic")
            {
                release = issue.fields.fixVersions[0].name;
            }
            else if (type == "Story")
            {
                release = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
            }
            else if (type == "Task")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Epic")
                {
                    release = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
                }
                else if (parentType == "Story")
                {
                    release = StoryList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
                }
            }
            else if (type == "Subtask")
            {
                var parentType = issue.fields.parent.fields.issuetype.name;
                if (parentType == "Epic")
                {
                    release = EpicList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
                }
                else if (parentType == "Story")
                {
                    release = StoryList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
                }
                else if (parentType == "Task")
                {
                    release = TaskList.FirstOrDefault(x => x.Id == issue.fields.parent.id).Release;
                }
            }

            return release;
        }

        //this is token that you need to connect to Jira
        public void SetToken()
        {
            basicAuth = Convert.ToBase64String(Encoding.ASCII.GetBytes(email + ":" + apikey));
        }
    }
}
