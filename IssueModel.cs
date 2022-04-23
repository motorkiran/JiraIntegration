namespace JiraDemo
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Self { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string Release { get; set; }
        public string IssueType { get; set; }
        public int? EpicId { get; set; }
        public string EpicTitle { get; set; }
        public int? StoryId { get; set; }
        public string StoryTitle { get; set; }
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public int SubtaskId { get; set; }
        public string SubtaskTitle { get; set; }
        public string AssignedTo { get; set; }
        public int? OriginalEstimate { get; set; }
        public int TimeLogged { get; set; }
    }
}
