namespace ProjectCard.Shared.WindowModule
{
    public interface IDialogWindowProperties
    {
        string Title { get; set; }
        string Message { get; set; }
        string OkText { get; set; }
        string CancelText { get; set; }
    }
}
