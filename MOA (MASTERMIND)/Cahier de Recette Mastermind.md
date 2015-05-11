Cahier de Recette
===================

----------

### Recette :


| Numéro | Description  | Résultat obtenu |
| :----: | :----------------- | :----:  |
|1| L'application invite le codeur à saisir son code secret.| OK |
|2| La solution du codeur contient 5 caractères exactement.| OK |
|3| L'application n'accepte que des chiffres, pour les choix du codeur comme du décodeur.| OK |
|4| Le décodeur n'a pas la possibilité de voir le code à trouver avant la fin de la partie.| **NOK**  |
|5| Après le choix du code à trouver, l'application invite le décodeur à saisir une première combinaison.| OK |
|6| Une fois la combinaison proposée par le décodeur, le codeur doit choisir les indices. | OK |
|7| Les 3 indices comptent respectivement les nombres: -de caractères bien placés, -de ceux bons mais mal placés, -et de ceux non présents dans le code secret.| OK |
|8| Les indices ne doivent pas préciser la position des caractères auxquels ils font référence.| OK |
|9| La partie s'arrête après une saisie du décodeur si celle-ci correspond au code secret, ou s'il s'agit de son dernier essai.| **NOK** |
|10| Le décodeur gagne la partie s'il a trouvé le bon code, ou si le décodeur s'est trompé à n'importe quel moment dans les indices.| OK |
|11| Une fois la partie terminée, le vainqueur est affiché.| **NOK** |
|12| Une fois la partie terminée, l'application propose de rejouer ou de quitter.| **NOK** |

### Résultat de la Recette & Remarques

- Changer le message de victoire en cas d'épuisement des essais (mauvais gagnant)
- Correction de la typo "Vote" en "Votre"
- Ajouter un écran de transition entre chaque mode
- Ajouter la proposition de redémarrer la partie
