namespace ASPNET.Models
{
    public enum Action
    {
        Delete,
        Create,
        Update
    }
    public class Toster
    {
        public string Text { get; set; }
        public Action Action { get; set; }
    }
}
