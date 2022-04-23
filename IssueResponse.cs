using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraDemo
{
    public class FixVersion
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public string releaseDate { get; set; }
    }

    public class NonEditableReason
    {
        public string reason { get; set; }
        public string message { get; set; }
    }

    public class Customfield10100
    {
        public bool hasEpicLinkFieldDependency { get; set; }
        public bool showField { get; set; }
        public NonEditableReason nonEditableReason { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public string name { get; set; }
        public string inward { get; set; }
        public string outward { get; set; }
        public string self { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
        public string entityId { get; set; }
        public int hierarchyLevel { get; set; }
    }

    public class Fields
    {
        public string summary { get; set; }
        public Status status { get; set; }
        public Priority priority { get; set; }
        public Issuetype issuetype { get; set; }
        public DateTime statuscategorychangedate { get; set; }
        public List<FixVersion> fixVersions { get; set; }
        public object resolution { get; set; }
        public object customfield_10510 { get; set; }
        public object customfield_10500 { get; set; }
        public string customfield_10501 { get; set; }
        public object customfield_10502 { get; set; }
        public List<object> customfield_10503 { get; set; }
        public object customfield_10504 { get; set; }
        public string customfield_10505 { get; set; }
        public object customfield_10506 { get; set; }
        public object customfield_10507 { get; set; }
        public object customfield_10508 { get; set; }
        public object customfield_10509 { get; set; }
        public DateTime? lastViewed { get; set; }
        public Customfield10100 customfield_10100 { get; set; }
        public List<object> labels { get; set; }
        public int? timeestimate { get; set; }
        public int? aggregatetimeoriginalestimate { get; set; }
        public List<object> versions { get; set; }
        public List<Issuelink> issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public List<object> components { get; set; }
        public object customfield_10696 { get; set; }
        public object customfield_10687 { get; set; }
        public object customfield_10567 { get; set; }
        public object customfield_10568 { get; set; }
        public object customfield_10569 { get; set; }
        public int? aggregatetimeestimate { get; set; }
        public Creator creator { get; set; }
        public List<Subtask> subtasks { get; set; }
        public Reporter reporter { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public string customfield_10200 { get; set; }
        public object customfield_10685 { get; set; }
        public object customfield_10686 { get; set; }
        public object customfield_10711 { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
        public object timespent { get; set; }
        public Project project { get; set; }
        public object aggregatetimespent { get; set; }
        public object customfield_10665 { get; set; }
        public object customfield_10666 { get; set; }
        public object customfield_10667 { get; set; }
        public object customfield_10668 { get; set; }
        public object customfield_10669 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public Watches watches { get; set; }
        public DateTime created { get; set; }
        public object customfield_10022 { get; set; }
        public object customfield_10660 { get; set; }
        public object customfield_10661 { get; set; }
        public object customfield_10662 { get; set; }
        public object customfield_10663 { get; set; }
        public object customfield_10300 { get; set; }
        public object customfield_10664 { get; set; }
        public object customfield_10654 { get; set; }
        public object customfield_10655 { get; set; }
        public object customfield_10656 { get; set; }
        public object customfield_10657 { get; set; }
        public object customfield_10658 { get; set; }
        public object customfield_10659 { get; set; }
        public DateTime updated { get; set; }
        public int? timeoriginalestimate { get; set; }
        public Description description { get; set; }
        public object customfield_10650 { get; set; }
        public object customfield_10651 { get; set; }
        public object customfield_10652 { get; set; }
        public object customfield_10653 { get; set; }
        public object security { get; set; }
        public object customfield_10646 { get; set; }
        public object customfield_10647 { get; set; }
        public object customfield_10648 { get; set; }
        public object customfield_10649 { get; set; }
        public object customfield_10000 { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10640 { get; set; }
        public string customfield_10002 { get; set; }
        public List<Customfield10003> customfield_10003 { get; set; }
        public object customfield_10400 { get; set; }
        public object customfield_10004 { get; set; }
        public object customfield_10511 { get; set; }
        public object customfield_10512 { get; set; }
        public object customfield_10513 { get; set; }
        public object environment { get; set; }
        public object customfield_10635 { get; set; }
        public object customfield_10514 { get; set; }
        public object customfield_10636 { get; set; }
        public object customfield_10516 { get; set; }
        public object customfield_10637 { get; set; }
        public string duedate { get; set; }
        public object customfield_10638 { get; set; }
        public object customfield_10639 { get; set; }
        public object customfield_10518 { get; set; }
        public Parent parent { get; set; }
    }

    public class OutwardIssue
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields fields { get; set; }
    }

    public class InwardIssue
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields fields { get; set; }
    }

    public class Issuelink
    {
        public string id { get; set; }
        public string self { get; set; }
        public Type type { get; set; }
        public OutwardIssue outwardIssue { get; set; }
        public InwardIssue inwardIssue { get; set; }
    }

    [JsonObject("AvatarUrls")]
    public class AvatarUrl
    {
        public string _48x48 { get; set; }
        public string _24x24 { get; set; }
        public string _16x16 { get; set; }
        public string _32x32 { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        //public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        //public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class Subtask
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields fields { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        //public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string accountType { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int? percent { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int? percent { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public bool simplified { get; set; }
        //public AvatarUrls avatarUrls { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Attrs
    {
        public string url { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string text { get; set; }
        public List<Content> content { get; set; }
        public Attrs attrs { get; set; }
    }

    public class Description
    {
        public int version { get; set; }
        public string type { get; set; }
        public List<Content> content { get; set; }
    }

    public class Customfield10003
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public int boardId { get; set; }
        public string goal { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class Parent
    {
        public int id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields fields { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public int id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class IssueResponse
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }


}
