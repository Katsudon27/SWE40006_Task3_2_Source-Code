namespace SWE_Task_3_2.Models
{
    public class listItem
    {
        //Attribtues for an item in the to-do list
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Done { get; set; }

    }
}
