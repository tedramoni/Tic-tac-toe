Cahier des Charges : Mastermind
===================


Dans le cadre de notre cour de Génie Logiciel, nous nous retrouvons dans le rôle de MOA, traduisant le besoin pour les équipes de développement.

----------


Spécifications
-------------

> **Rappel:**

> Le Mastermind ou Master Mind est un jeu de société pour deux joueurs dont le but est de trouver un code. C'est un jeu de réflexion, et de déduction, inventé par Mordecai Meirowitz dans les années 1970 alors qu'il travaillait comme expert en télécommunications. Il rappelle un jeu sur papier plus ancien d'au moins un siecle appelé "Bulls and Cows".
>
> *Source: Wikipédia.*

----------
#### Introduction au problème : But du jeu de Mastermind.

- Le jeu se joue à deux joueurs, un codeur, et un décodeur.

- Le codeur choisis une combinaison de 5 chiffres qu'il garde secret.

- Le décodeur a pour but de trouver la combinaison de chiffres grâce aux indications données par le codeur à chacun de ses essais.


----------
#### Déroulement du jeu.

 1.  Le codeur choisit une combinaison de 5 chiffres (allant de 0 à 9).

 2. Le décodeur propose alors une première solution. (Exemple: 18756)

 3. Le codeur renvoie alors des indices qui correspondent d'une part au nombre de chiffres trouvés et bien placés, et d'autre part le nombre de chiffres trouvés mais mal placés (sans préciser desquels il s'agit).

 4. Le jeu s'arrête quand le décodeur parvient à proposer la chaîne exacte du codeur (bons caractères, et dans le bon ordre), ou bien quand celui-ci n'y arrive pas avant le nombre de tours impartis qui est de **10 tours**.
 
 5. À la fin d'une partie, la combinaison est révélée. Si la limite de 10 tours est atteinte, la validité des indices fournis par le codeur est vérifié. Si celui-ci n'a pas induit en erreur le décodeur, il est déclaré gagnant par le jeu. Dans le cas contraire, les erreurs d'indices sont indiquées et c'est le décodeur qui remporte la partie. Si le décodeur a renseigné la bonne combinaison, il est déclaré vainqueur dans tous les cas.
 
 6. Le vainqueur est ensuite affiché à l'écran, et il est alors possible de relancer une partie ou de quitter l'application.



