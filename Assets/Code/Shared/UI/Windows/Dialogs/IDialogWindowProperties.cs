namespace Framework.Shared.UI.Windows.Dialogs
{
    public interface IDialogWindowProperties
    {
        string Title { get; set; }
        string Message { get; set; }
        string OkText { get; set; }
        string CancelText { get; set; }
    }
}
