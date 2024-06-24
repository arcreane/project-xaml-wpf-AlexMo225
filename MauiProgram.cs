using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using SharpHook;
using Windows.Graphics;

namespace Tetris;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Configuration de l'application MAUI
        builder
            .UseMauiApp<App>() // Utilise l'application définie par App
            .UseMauiCommunityToolkitMediaElement() // Utilise le MediaElement du toolkit communautaire MAUI
            .ConfigureFonts(fonts =>
            {
                // Ajout des polices à l'application
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if WINDOWS
        // Configuration des événements de cycle de vie spécifiques à Windows
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    // Obtient le handle de la fenêtre native
                    var nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    // Obtient l'ID de la fenêtre Win32 à partir du handle de la fenêtre native
                    var win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    // Obtient l'objet AppWindow à partir de l'ID de la fenêtre
                    var winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                    if (winuiAppWindow.Presenter is OverlappedPresenter p)
                    {
                        // Si le présentateur est de type OverlappedPresenter, maximise la fenêtre
                        p.Maximize();
                    }
                    else
                    {
                        // Sinon, redimensionne et déplace la fenêtre
                        const int width = 1200;
                        const int height = 800;
                        winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                    }
                });
            });
        });
#endif

        // Création d'un hook global pour intercepter les touches
        var hook = new TaskPoolGlobalHook();
        // Abonnement à l'événement KeyPressed pour gérer les touches pressées
        hook.KeyPressed += TetrisController.OnKeyPressed;

#if DEBUG
        // Ajout du support de logging en mode débogage
        builder.Logging.AddDebug();
#endif
        _ = hook.RunAsync(); // Exécution du hook global en asynchrone

        return builder.Build(); // Construction et retour de l'application configurée
    }
}
