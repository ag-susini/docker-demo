namespace todo_api.Data
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public bool Editing { get; set; }
    }
}