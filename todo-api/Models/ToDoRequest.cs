namespace todo_api.Models
{
    public class ToDoRequest
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
        public bool Editing { get; set; }
    }
}