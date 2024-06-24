using SharpHook;

namespace Tetris;

// Classe statique servant de contrôleur pour les événements de Tetris
public static class TetrisController
{
    // Événement déclenché lorsqu'une touche du clavier est pressée
    public static event EventHandler<KeyboardHookEventArgs>? KeyPressed;

    // Méthode appelée lorsque l'événement de touche pressée se produit
    // Elle déclenche l'événement KeyPressed en passant l'expéditeur et les arguments de l'événement
    public static void OnKeyPressed(object? sender, KeyboardHookEventArgs e) => KeyPressed?.Invoke(sender, e);
}
