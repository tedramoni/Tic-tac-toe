#Tic-Tac-Toe

## Spécifications Fonctionnelles détaillées

Exemple de tic-tac-toe version normale :

![Exemple de morpion version normale](http://i.imgur.com/Okm4aMM.png "Optional title")

###Application

Le jeu sera réalisé en application console.

Pour la notion de tour par tour, nous proposons de réaliser un programme pour une seule machine, sur laquelle les deux joueurs joueront à tour de rôle.

###Déroulement de la partie

Après le choix des noms et symboles, les joueurs s'affrontent lors de manches successives (minimum 5).
Chaque manche peut se solder par une égalité, ou une victoire de l'un des joueurs; le cas échéant ce joueur marque un point.
En cas d’égalité au bout de 5 manches, des manches sont ajoutées en « mort subite », autrement dit le premier joueur qui marque un point gagne la partie.

**Affichage**

Sont affichés en permanence:
-Les noms des joueurs, dès lors qu'ils sont saisis, et leurs scores respectifs
-La grille de jeu et le joueur dont c'est le tour, dès lors qu'une manche est en cours

Exemple de grille de jeu affichée dans la console :

    |---|---|---| 
    |   | X | O |
    |---|---|---|
    |   | O | X |
    |---|---|---|
    | O |   | X |
    |---|---|---|

**Choix du nom et du symbole**

Au début de la partie, le joueur 1 saisit son nom et choisit son symbole, « X » et « O », puis le joueur 2 saisit son nom et obtient le deuxième symbole.

**Déroulement d'une manche**

Le joueur dont c'est le tour est invité à saisir le numéro de la case dans laquelle il souhaite placer son pion. En cas de saisie incorrecte (case déjà occupée), il devra recommencer sa saisie.
Si la case choisie était inoccupée, le pion du joueur y est ajouté.

- Dans le cas où ce pion viendrait former un alignement avec 2 autres pions du même joueur, ce dernier marque un point et la manche est terminée.
- Si ce pion ne forme aucun alignement et que la grille de jeu est remplie, la manche s'achève sur une égalité.
- Dans les autres cas, c'est au tour de l'autre joueur.

**Nouvelle partie**

Lors de la fin d'une partie, un message indique quel joueur est vainqueur, puis il est proposé de recommencer une partie.
Nous proposons cependant à la MOA de donner aux joueurs la possibilité de recommencer une partie à n'importe quel moment du jeu, en entrant par exemple une commande en lieu et place de leur choix de placement de pion.

Exemples de commandes :

- /retry
Recommencer une nouvelle partie (la partie est effacée, une nouvelle est relancée)

- /quit
Quitter la partie (la partie est sauvegardée)

###Stockage de la partie

L’état de la partie doit être stocké au fur et à mesure, ce qui permettra en cas d'arrêt volontaire (ou non) de l'application de reprendre la partie en cours.
Nous proposons donc de stocker l'état de la partie dans un fichier local, mis à jour à chaque action. Ce fichier est réinitialisé une fois la partie gagnée.

Au lancement de l'application, si le fichier contient les valeurs d'une partie stoppée, cette dernière est rechargée .
