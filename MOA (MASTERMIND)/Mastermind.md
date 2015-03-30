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

- le décodeur a pour but de trouver la combinaison de chiffre grâce aux indications données par le codeur à chacun de ses essais.


----------
#### L'expression fonctionnelle du besoin : Déroulement du jeu.

 1.  Le codeur choisit une combinaison de 5 chiffres (allant de 0 - 9).

 2. Le décodeur propose alors une première solution. (Exemple 18756)

 3. Le codeur renvoi alors des indices. Ces indices peuvent indiquer le nombre de chiffres trouvés et bien placés et le nombre de chiffres trouvés mais mal placés, sans préciser desquels il s'agit.

 4. Le jeu s'arrête quand le décodeur parviens à proposer la chaîne exacte et dans le bonne ordre du codeur, ou bien que celui-ci n'y arrive pas avant le nombre de tours impartis qui est de **10 tours**.

----------
L'application demandée devra ainsi couvrir le besoin de bon déroulement du jeu, en respectant à la fois les règles énoncées ci-dessus, mais également les possibilités d'évolutions de celles-ci; certains détails n'étant pas encore fixés (nombre de tours, de joueurs, chiffres ou couleurs, ...)
