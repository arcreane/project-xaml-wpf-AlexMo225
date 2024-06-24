namespace Tetris.Extensions;

// Classe statique pour les extensions de tableaux
public static class ArrayExtensions
{
    // Méthode d'extension pour accéder aux éléments d'un tableau multidimensionnel avec des indices circulaires
    public static T At<T>(this T[,] array, params int[] indices)
    {
        // Pour chaque indice fourni
        for (int i = 0; i < indices.Length; i++)
        {
            var dimIdx = indices[i]; // Indice courant
            var dimLen = array.GetLength(i); // Longueur de la dimension courante

            // Ajuste l'indice s'il est négatif en le faisant circuler dans les limites de la dimension
            while (dimIdx < 0)
            {
                dimIdx += dimLen;
            }

            // Ajuste l'indice s'il dépasse la longueur de la dimension en le faisant circuler dans les limites de la dimension
            while (dimIdx >= dimLen)
            {
                dimIdx -= dimLen;
            }

            // Met à jour l'indice avec la valeur ajustée
            indices[i] = dimIdx;
        }

        // Retourne l'élément à la position ajustée dans le tableau
        return (T)array.GetValue(indices)!;
    }
}
