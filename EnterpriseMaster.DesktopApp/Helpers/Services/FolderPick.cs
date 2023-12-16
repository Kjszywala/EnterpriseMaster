using Microsoft.WindowsAPICodePack.Dialogs;

namespace EnterpriseMaster.DesktopApp.Helpers.Services
{
    public class FolderPick : Interfaces.IFolderPick
    {
        public string DisplayFolderPicker()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                return dialog.FileName;
            return "";
        }
    }
}