using System.ComponentModel.DataAnnotations;

namespace dotnet_backend.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public Priority Priority { get; set; }

        public IssueType IssueType { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Completed { get; set; }

    }
    public enum Priority
    {
        low, medium, high
    }

    public enum IssueType
    {
        Feature, Bug, Documantation
    }
}
