using Windows.Storage.Pickers;

namespace UnoApp2;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this
            .Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"))
            .Content(new StackPanel()
                .VerticalAlignment(VerticalAlignment.Center)
                .HorizontalAlignment(HorizontalAlignment.Center)
                .Children(
                    new Button().Name(out var button).Content("TEST")
                ));

        button.Click += async (sender, args) =>
        {
            var picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = "TestDocument.txt",
                DefaultFileExtension = ".txt"
            };
            var saveFile =  await picker.PickSaveFileAsync();
            
            CachedFileManager.DeferUpdates(saveFile);
            await FileIO.WriteTextAsync(saveFile, "Test File Content");
            await CachedFileManager.CompleteUpdatesAsync(saveFile);
        };

    }
}

