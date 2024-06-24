namespace Tetris;

// Classe abstraite représentant une forme de Tetris
public abstract class TetrisShape
{
    // Méthode abstraite pour obtenir la couleur de la forme
    public abstract Color GetColor();
    
    // Méthode abstraite pour construire le modèle de la forme en fonction de la rotation
    public abstract (int x, int y)[] BuildTemplate(TetrisRotation rotation);
    
    // Méthode virtuelle pour obtenir la largeur de la forme
    public virtual int GetShapeWidth((int x, int y)[] template) => template.Select(t => t.x).Max();
    
    // Méthode virtuelle pour obtenir la hauteur de la forme
    public virtual int GetShapeHeight((int x, int y)[] template) => template.Select(t => t.y).Max();
    
    // Méthode virtuelle interne pour appliquer les limites au modèle de la forme
    internal virtual (int x, int y)[] ApplyBoundsToTemplate((int x, int y)[] template, int x, int y) => template.Select(t => (t.x + x, t.y + y)).ToArray();
    
    // Méthode virtuelle pour construire la forme en fonction des coordonnées et des dimensions disponibles
    public virtual (int x, int y)[] Build(int x, int y, int availableWidth, int availableHeight, TetrisRotation rotation)
    {
        var template = BuildTemplate(rotation);
        var templateWidth = GetShapeWidth(template);
        var templateHeight = GetShapeHeight(template);

        if (x + templateWidth >= availableWidth)
        {
            x = (availableWidth - 1) - templateWidth;
        }

        if (y + templateHeight >= availableHeight)
        {
            y = (availableHeight - 1) - templateHeight;
        }

        return ApplyBoundsToTemplate(template, x, y);
    }
}

// Définition de la forme TangoShape
public class TangoShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {

            TetrisRotation.Degrees0 => [
                        (1, 0),
                (0, 1), (1, 1), (2, 1),
            ],

            
            TetrisRotation.Degrees90 => [
                (0, 0),
                (0, 1), (1, 1),
                (0, 2),
            ],

            TetrisRotation.Degrees180 => [
                (0, 0), (1, 0), (2, 0),
                        (1, 1),
            ],

            
            TetrisRotation.Degrees270 => [
                        (1, 0),
                (0, 1), (1, 1),
                        (1, 2),
            ],

            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("a000f0");
    }
}

// Définition de la forme OscarShape
public class OscarShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            
            TetrisRotation.Degrees0 or TetrisRotation.Degrees90 or TetrisRotation.Degrees180 or TetrisRotation.Degrees270 => [
                (0, 0), (1, 0),
                (0, 1), (1, 1),
            ],
            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("f0f000");
    }
}

// Définition de la forme IndiaShape
public class IndiaShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            TetrisRotation.Degrees0 or TetrisRotation.Degrees180 => [
                (0, 0), (1, 0), (2, 0), (3, 0),
            ],
            TetrisRotation.Degrees90 or TetrisRotation.Degrees270 => [
                (0, 0),
                (0, 1),
                (0, 2),
                (0, 3),
            ],
            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("00f0f0");
    }
}

// Définition de la forme JuliettShape
public class JuliettShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            
            TetrisRotation.Degrees0 => [
                        (1, 0),
                        (1, 1),
                (0, 2), (1, 2),
            ],

            
            TetrisRotation.Degrees90 => [
                (0, 0),
                (0, 1), (1, 1), (2, 1),
            ],

            
            TetrisRotation.Degrees180 => [
                (0, 0), (1, 0),
                (0, 1),
                (0, 2),
            ],

            
            TetrisRotation.Degrees270 => [
                (0, 0), (1, 0), (2, 0),
                                (2, 1),
            ],

            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("0000f0");
    }
}

// Définition de la forme LimaShape
public class LimaShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            
            TetrisRotation.Degrees0 => [
                (0, 0),
                (0, 1),
                (0, 2), (1, 2),
            ],

        
            TetrisRotation.Degrees90 => [
                (0, 0), (1, 0), (2, 0),
                (0, 1),
            ],

    
            TetrisRotation.Degrees180 => [
                (0, 0),(1, 0),
                    (1, 1),
                    (1, 2),
            ],

                    
            TetrisRotation.Degrees270 => [
                                (2, 0),
                (0, 1), (1, 1), (2, 1),
            ],

            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("f0a000");
    }
}

// Définition de la forme SierraShape
public class SierraShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            
            TetrisRotation.Degrees0 or TetrisRotation.Degrees180 => [
                        (1, 0), (2, 0),
                (0, 1), (1, 1),
            ],

            
            TetrisRotation.Degrees90 or TetrisRotation.Degrees270 => [
                (0, 0),
                (0, 1), (1, 1),
                        (1, 2),
            ],

            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("00f000");
    }
}

// Définition de la forme ZuluShape
public class ZuluShape : TetrisShape
{
    // Construction du modèle de la forme en fonction de la rotation
    public override (int x, int y)[] BuildTemplate(TetrisRotation rotation)
    {
        return rotation switch
        {
            
            TetrisRotation.Degrees0 or TetrisRotation.Degrees180 => [
                (0, 0), (1, 0),
                        (1, 1), (2, 1),
            ],

        
            TetrisRotation.Degrees90 or TetrisRotation.Degrees270 => [
                        (1, 0),
                (0, 1), (1, 1),
                (0, 2),
            ],

            _ => throw new NotSupportedException(),
        };
    }

    // Obtention de la couleur de la forme
    public override Color GetColor()
    {
        return Color.FromArgb("f00000");
    }
}
