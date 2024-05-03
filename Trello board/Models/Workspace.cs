namespace Trello_board.Models
{
    public class Workspace
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public  int[] tasksGroup { get; set; }

    }
}
