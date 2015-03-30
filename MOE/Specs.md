#Tic-Tac-Toe

## Spécification Technique de Besoin 

Exemple de morpion version normale :

![Exemple de morpion version normale](http://i.imgur.com/Okm4aMM.png "Optional title")

**Affichage**

Dans un premier temps, la solution sera réalisée en application console, 
Exemple de ce que l'application affichera dans un premier temps en console :

    |---|---|---| 
    |   | X | O |
    |---|---|---|
    |   | O | X |
    |---|---|---|
    | O |   | X |
    |---|---|---|

Pour la notion de tour par tour, nous proposons la solution de réaliser une seule et unique application, sur laquelle les deux joueurs jouerons sur la même machine.

**Choix du symbole**

Nous choisirons les traditionelles symboles « X » et « O » pour la première solution technique, à moins que la MOA ne s'y oppose et propose ses propres symboles.

Au début de la partie, le joueur 1 choisit son symbole, et le joueur 2 obtient le deuxième symbole. 
En cas d’égalité au bout des 5 manches, des manches sont ajoutées en « mort subite ». La première manche gagnée permet de gagner la partie.

** Stockage de la partie** : 

L’état de la partie doit être stocké au fur et à mesure, ce qui permettra en cas d'arrêt volontaire (ou non) de l'application de reprendre la partie en cours.
Nous proposons donc de stocké sur disque dur (fichier texte, binaire ou autre) à chaques tours joués.

Ce qui implique donc la possibilité quand le jeu est redemaré de recharger la dernière partie si le fichier contient les valeurs d'une partie stoppée.

Lors de la fin d'une partie, le fichier est vidé.


**Recommencement de la partie** : 

Il sera proposer via console de recommencer une partie après qu'une partie soit terminée. Nous proposons cependant à la MOA la possibilité pour les joueurs de recommencer une partie à n'importe quel moment de la partie, en entrant par exemple une commande (!retry) en lieu et place de leur symbole.


Exemple de commande de base possible d'entrer à la place du symbole :

- /retry

Recommencer une nouvelle partie (pas de sauvegarde)

- /quit

Quitter la partie (la partie est sauvegardée)




