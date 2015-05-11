
### *Rapport de projet* – AGL – L3 MIAGE

> ##### **Thomas Negrault, Clément Hémidy,  Alexandre Lavigne,  Maxime Boussard,  Anaïs Rojbi,  Pierre Grosjean**


# 1 - Introduction
## Présentation du sujet

Dans le cadre de l’UE « Atelier de Génie Logiciel », il nous a été demandé de conduire un projet de développement logiciel s’appuyant sur des outils informatiques qui en facilitent la conception et la mise en œuvre technique. Le sujet proposé a pour but de se rapprocher un peu plus des projets “réels”, sous la forme de deux missions (MOE et MOA) qui concernent le développement de jeux de société en coopération avec d’autre groupes.
Tandis que la partie MOA consiste à énoncer le besoin d’un jeu de Mastermind, la partie MOE doit répondre à un appel d’offres du jeu de Tic-Tac-Toe (et l’implémenter en langage C#).

À travers ces deux missions, nous sommes amenés à synchroniser notre travail de groupe et à communiquer avec deux autres équipes. Pour mener à bien ce projet, un certain nombre de contraintes sont à prendre en compte et l’équipe devra s’appuyer sur des moyens élaborés et adaptés à ces tâches. Des outils de génie logiciel englobant les différentes phases du projet et permettant le travail simultané de tous les membres, tels que GitHub (pour la gestion des versions) ou Trello (pour la répartition des tâches), sont vivement recommandés.

##Méthode de travail et organisation de l’équipe

Nous avons en premier lieu créé un groupe Facebook afin d’échanger rapidement les premières informations, se guider mutuellement pour la suite des installations, et pouvoir communiquer avec toute l’équipe de manière rapide.
Ensuite, nous avons créé des comptes sur GitHub et rejoint un projet dans lequel nous avons créé deux sous-dossiers, respectivement pour les parties MOA (Maîtrise d’Ouvrage) et MOE (Maîrise d’Oeuvre).

L’équipe s’est scindée en deux sous-équipes:

- **Anaïs, Maxime et Pierre** se sont attelés à la partie rédactionnelle, consistant à faire le travail d’analyse et réaliser les différents documents demandés, tout en restant attentifs aux demandes des autres groupes.

- **Alexandre, Clément et Thomas** ont quant à eux réalisé la partie fonctionnelle. Ils se sont ainsi essentiellement concentrés sur le développement de l’application Tic-Tac-Toe et des tests associés.

#2 - Partie Rédactionnelle
##MOA (Mastermind)

En tant que MOA (`Maîtrise d’OuvrAge`) du jeu Mastermind, nous avons été chargés d’en établir le cahier des charges afin d’exprimer fonctionnellement les besoins attendus. Ce cahier des charges a été réalisé à partir des règles de base du jeu, sans ajouter de variantes, de fonctionnalités extravagantes, et en restant dans une optique réaliste d’utilisation du jeu.

Cependant, le rôle de l’un des deux joueurs (celui qui crée la combinaison secrète à trouver) nous paraissant assez peu amusant en l’état, nous avons donc décidé de lui laisser la possibilité de se tromper au moment de fournir les indices de décodage à l’autre joueur (comme sur un vrai jeu de plateau, ce qui le force à être attentif) plutôt que de générer les indices automatiquement par programme.

Lors de l’ajout d’une consigne à la dernière séance, nous avons ajouté au besoin la possibilité pour un joueur de jouer seul contre l’ordinateur, auquel cas le code secret est généré aléatoirement et les indices calculés sans erreur possible. Cet ajout nous a plu, les deux modes de jeu (Contre l’ordinateur ou Deux joueurs) étant tous deux simples, réalistes et amusants.

Par la suite, nous avons également écrit le cahier de recettes de l’application attendue. Il a suffit de suivre point par point le besoin exprimé dans le cahier des charges en s’imaginant un scénario test, et relever tout ce qui devait être respecté dans le programme demandé.

##MOE (Tic-tac-toe)

Le projet de MOE (`Maîtrise d’OEuvre`) que nous devons réaliser consiste à développer une application C# permettant de jouer au jeu du Tic-Tac-Toe (également appelé morpion). Cette application doit permettre à deux joueurs de placer des marques (X ou O) sur une grille de 3x3 cases. Un joueur est considéré comme gagnant dès lors qu’il réussit à placer trois marques respectives dans une rangée horizontale, verticale ou diagonale.

En nous attachant à lever dès le départ les points d’obscurité du cahier des charges en posant toutes les questions nécessaires à la MOA du Tic-Tac-Toe, nous nous sommes appliqués à ne pas prendre en compte dans notre cahier de spécifications fonctionnelles détaillées les hypothèses ne faisant pas directement écho au besoin.

Cette partie s’est révélée assez intuitive, mais a nécessité beaucoup de réflexion car il a fallu se représenter à la fois le scénario d’utilisation de l’application (suivant le cahier des charges), et réfléchir dans le même temps à ce que cela représenterait pour nous en terme d’implémentation (bien qu’il s’agisse d’étapes bien distinctes, nous avons naturellement anticipé notre travail futur en évitant de proposer des solutions qui seraient inutilement trop compliquées à réaliser).

#3 - Partie Fonctionnelle
##Mécanismes et patterns implémentés

![UML Schema](http://i.imgur.com/TnG7kZD.jpg)

###Nous avons découpé notre application en plusieurs blocs :

####Les modèles – `Game, Round, Player et Board`

Ces objets ont pour but de stocker l’image de la partie en cours.

####Les interfaces & les implémentations

Utiliser des interfaces nous a permis d’éviter les problèmes de dépendances entre nos différentes classes. En définissants des “squelettes” sans se préoccuper du fonctionnement interne, nous avons pu créer plusieurs implémentations d’une interface sans changer le code dans lequel elle est utilisée. 

Prenons l’exemple de l’interface IGameRepository : dans le code fonctionnel nous utilisons le repository sans connaître son fonctionnement interne. L’implémentation peut stocker sous le format JSON ou le format XML, le tout c’est qu’elle sauvegarde un objet **Game** et qu’elle charge un objet **Game**.

Cette méthode est utilisée sur l’ensemble du projet.

###La Dependency Injection

Nous utilisons également la Depency Injection permettant d'implémenter le principe de l'inversion de contrôle (IOC). Il consiste à créer dynamiquement (injecter) les dépendances entre les différentes classes. Ainsi les dépendances entre composants logiciels ne sont plus exprimées dans le code de manière statique mais déterminées dynamiquement à l'exécution. Le code des classes est dépourvu d'instanciation d’objets reconnaissables à l’utilisation de “new” en dehors des classes suffixées par “factory” qui ont pour but de réaliser cette instanciation.

Ceci nous permet par exemple de changer d’implémentation rapidement et simplement.

###Single Responsibility Principle

![SRP](http://i.imgur.com/yEAgSuk.png)

Nous avons utilisé le design pattern **Single Responsibility Principle** qui consiste à découper les fonctionnalités au maximum et ainsi concevoir et réaliser chaque classe pour qu’elle n’ai une seule tâche à accomplir. Puisqu’une classe a une simple tâche a accomplir, il doit y avoir une seule raison pour qu’elle change. Cela permet de réduire la complexité du programme car chaque fonctionnalité peut être traité et modifié séparément.

Le code est alors plus robuste, plus facile à lire et à comprendre avec un nommage des classes adapté. Le découpage permet également de faciliter les tests unitaires.

###Test unitaires

Afin de s’assurer du bon fonctionnement du programme et de ses fonctionnalités, nous avons mis en place des tests unitaires. Ces tests couvrent les fonctions représentatives du programme  relatives au bon déroulement de la partie et à la sauvegarde et au chargement de la partie.

Les tests unitaires rentrent dans la logique de pérennisation du programme, ils permettent de trouver les erreurs rapidement en identifiant le/les module(s) non-fonctionnel(s), sécuriser la maintenance en obligeant à faire des modifications dans le code ou en réécrivant les tests pour correspondre aux nouvelles attentes.
Les tests unitaires dans ce projet utilisent le framework NUnit pour .NET, qui est open-source.

Les fonctions de type Assert employées dans les tests unitaires permettent, comme leur nom l’indique, d’affirmer qu’une opération effectuée renvoie la valeur attendue ou non.
Les tests unitaires sont inclus dans la solution TicTacToe, dans un projet dédié “TicTacToeUnitTest”.

##Présentation des fonctionnalités

Le TicTacToe est un jeu à deux joueurs humains, en tour par tour, et dont le but est d’aligner trois symboles sur une grille de 3x3. Il est constitué de cinq manches, une manche est finie quand un joueur a aligné 3 symboles ou que le jeu est bloqué.

En cas d’égalité au bout des 5 manches, des manches sont ajoutées en « mort subite ». La première manche gagnée permet de gagner la partie.

###Interface

![SCREEN1](https://i.imgur.com/yQBNZUV.png)
> Choix des prénoms

![SCREEN2](https://i.imgur.com/G6YDhXs.png)
> Choix d'une case

![SCREEN3](https://i.imgur.com/PhXEftU.png)
> Choix d'une case

![SCREEN4](https://i.imgur.com/gqJlsmk.png)
> Choix d'une case

![SCREEN5](https://i.imgur.com/QeIlhjy.png)
>  Fin de la partie

L’interface est composée:

 - d’un bandeau supérieur affichant:
	- le numéro du round en cours
	- du listage des commandes du menu:
		- /retry pour lancer une nouvelle partie
		- /quit pour quitter le jeu, tout en sauvegardant la partie
	- de l’historique des scores (nombres de parties gagnées)
 - De la grille de jeu, indiquant pour chaque case son numéro si elle est inoccupée, le symbole du joueur qui l’occupe sinon.
 - D’une phrase indiquant quel joueur doit entrer son choix de case

###Déroulement d’une partie

Au lancement du programme, le joueur numéro 1 est invité a saisir son nom et a choisir son symbole, X ou O. Le joueur deux entre alors son nom et le programme l’informe du symbole qui lui est attribué.

L’interface décrite ci-dessus est alors chargée et le joueur 1 est alors invité a choisir la case ou il souhaite placer son symbole, en entrant un numéro entre 1 et 9 et en validant en appuyant sur la touche Enter. La grille est alors rechargée pour prendre en compte le symbole nouvellement ajouté. C’est alors au joueur deux de jouer et ainsi de suite jusqu'à une victoire ou une égalité (grille pleine mais aucun gagnant).
En cas de victoire d’un des deux joueurs, son score dans le bandeau supérieur est mis a jour est le round suivant est chargé.

Si un joueur remporte 3 rounds, le jeu est alors terminé, sinon le gagnant est celui ayant le plus de victoires dans les 5 rounds.

En cas d’égalité, une manche de mort subite est lancée et le gagnant de cette manche est nommé vainqueur du jeu.

À la fin d’une partie, les joueurs sont invités à en recommencer une nouvelle, en entrant “o” pour oui ou “n” pour non.

À tout moment, les joueurs peuvent entrer une commande à la place du numéro de la case, /retry pour lancer une nouvelle partie ou /quit pour quitter le jeu, tout en sauvegardant la partie.
La partie est sauvegardé lorsque l’on quitte le programme, que ce soit en utilisant la commande /quit ou en fermant la console. La partie est alors restaurée lors du prochain lancement du programme.

#4 - Bilan du projet

##Difficultés rencontrées et solutions

**IDE :** Visual Studio n’a pas été conservé à cause de la diversité des systèmes d’exploitation utilisé par les membres du groupe de travail. Pour développer le projet avec le langage C# tout en gardant nos environnement initiaux (MAC OS X, Ubuntu et Windows) nous avons utilisé MonoDevelop (Xamarin) étant cross-platform et open-source. 

##Améliorations possibles

- Amélioration de l’affichage du plateau en console (couleurs)
- Interface graphique
- Jeu en réseau

##Éléments ratés / non effectués

- Certaines classes (TicTacToeRunner, TicTacToeGame et TicTacToeRound) ne sont pas assez découpées (SRP). Et ceci implique qu’il n’a pas été possible de créer les tests unitaires pour ces trois classes.
- Non utilisation d’un framework MOCK

#5 - Conclusion

##Ressenti

Ce projet s’est démarqué de ceux que nous avions pu réaliser au cours de nos 3 ans à l’IUT de plusieurs manières, notamment le travail en groupe de 6 (habituellement 2 ou 3). Dans une optique de réalisme, nous avons trouvé ceci très intéressant car la problématique de répartition et coordination des tâches est réelle dans le monde du travail et pouvoir l’aborder de manière encadrée durant nos études est très appréciable.

Il en va de même pour la séparation des tâches MOA / MOE : cela nous a permis de mieux cerner ces différents rôles (que nous serons sûrement amenés à remplir plus tard) et en saisir au mieux les spécificités.
Qu’est-ce qu’on peut perdre comme temps en formalités !

Il est difficile d’arriver dans le code d’un projet, surtout quand il se veut SRP et de comprendre son fonctionnement, d’arriver à l’utiliser pour faire des tests unitaires notamment.

##Apports du projet

D’un point de vue technique, ce projet nous a permis d’acquérir des connaissances voire de découvrir le C#, de nous familiariser avec des outils propres à l’AGL, et de redécouvrir une méthode de développement logiciel qui exige de suivre une démarche rigoureuse et structurée au travers du cycle en V. Ce projet nous a également permis d’apprendre à utiliser le gestionnaire de versions GIT, ainsi que le service d'hébergement GitHub permettant d'héberger gratuitement notre dépôt GIT. L’utilisation de GIT nous a permis de travailler à plusieurs sur le même projet et d’avoir un historique des modifications apportées au code afin de pouvoir revenir à une version précédente en cas de régression ou d’effet de bord (une nouvelle fonctionnalité en impacte une autre).

##Suggestions

À l’avenir, il serait sûrement apprécié par les étudiants de disposer d’une séance à part supplémentaire pour introduire le langage C#. Ce souhait a également été fait auprès du Directeur des Études, car malgré les apparences durant les séances de TP nous étions enthousiastes à l’idée d’ajouter un nouveau langage à nos compétences et aurions juste aimé avoir un petit peu plus de temps pour nous y préparer !

Quant à l’organisation du projet en lui-même, peu de choses seraient à améliorer, si ce n’est une clarification plus rapide lors de la première séance de la répartition des sujets. Un tableau récapitulatif par groupe (indiquant quels sujets MOA/MOE ainsi que les autres groupes avec qui être en contact et leur adresse) est certes trivial, mais pré requis à tout travail.
En dehors de cela, les sujets sont de difficulté adaptée. Ne changez rien !
