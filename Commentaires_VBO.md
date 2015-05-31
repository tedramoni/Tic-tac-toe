# TL; DR

17/20

Très bon travail dans l'ensemble, équipe qui paraissait studieuse lors des séances et qui produit un très bon résultat, tant MOA que MOE en ayant su adapter ses méthodes de travail. Bonne utilisation de markdown et du respect des consignes.

# MOA Mastermind

## Cahier des charges (CdC)

* Il est bon d'avoir rappelé le contexte du besoin, même si c'est un peu maladroit, mais inutile de dire que vous êtes la MOA.
* Le besoin est expliqué d'un point de vue fonctionnel sans rentrer dans des détails techniques, ce qui est très bien. La MOE dispose d'une certaine liberté d'implémentation notamment au niveau de l'interface.

## Cahier de recettes (CdR)

* Il y a une incohérence entre le CdC et le CdR dans le scénario numéro 7 : on précise qu'on attend trois sorties (bons, bons mal placés et non présents) alors que le CdC précise seulement deux sorties (bons et bon mal placés).
* Aucune référence à la fonctionnalité bonus dans le CdR.
* Pas de vérification de la limite des 10 essais, seulement de son `dernier essai`.
* Certains scénarios sont multiples (e.g. n°9, n°10 et n°12) : il aurait fallu les scinder en deux scénarios.

## Soutenance

* Une fonctionnalité permettant de nommer les joueurs a été ajoutée, ce qui peut-être effectivement intéressant, mais elle n'était pas demandée.
* L'incohérence relevée sur les sorties attendues était implémentée comme attendue, ce qui semble assez logique et rentre dans le domaine de liberté de la MOE.
* Cette règle du cahier des charges (les indices) a donné lieu à une ambiguité lors de la soutenance avec le cas `44444` où seulement deux `4` étaient dans la réponse. J'admets que c'est un cas limite, on aurait pu préciser que *si un chiffre est `bien placé`, un chiffre identique ne peut être `mal placé` que si le chiffre est présent à une autre position dans la combinaison et que cette position n'a pas été découverte comme `bien placée`*.
* Le caractère très bugué du produit (erreur récurrente sur le vainqueur) vous a fait prendre la bonne décision de ne pas accepter la livraison.

# MOE TicTacToe

## Spécifications fonctionnelles

* Bonne présentation à la fois de l'interface et du déroulement du jeu : c'est clair.
* La spécification du stockage de la partie ne précise pas le format du fichier, ce qui est bien si l'on s'en tient au CdC initial, mais montre une absence de mise à jour suite à la fonctionnalité bonus.

## Spécifications techniques

* Absente mais présence d'un diagramme de classes lisibles et compréhensible, bon pour moi.

# Rapport

* Pourquoi le titre du document est en titre de niveau 3 ?
* Compte-rendu plutôt complet, félicitations. Le style est un peu poussif et on a du mal à respirer sur certaines phrases.
* Bel effort sur le diagramme de classe, il reste lisible.
* Pourquoi avoir séparer les tests du code source ? Il faut garder un maximum de cohérence entre ces deux éléments. Les tests ne sont pas des éléments que l'on lance de temps en temps, ils doivent être exécutés à chaque compilation. Plus tôt vous détectez une erreur, mieux c'est.
* La partie **Bilan** reste un peu timide à mon goût. Vous avez découvert de nouveaux outils que vous avez utilisés de façon basique (comme tout nouvel outil) mais avez-vous ressenti le potentiel de ceux-ci ? Allez-vous essayer de les utiliser dans votre quotidien professionnel ? Connaissez-vous de meilleurs outils ou des éléments de comparaison ?
* De la même façon, quand vous présentez les principes de programmation utilisés, les avantages présentés manque de conviction. Donnez des exemples en rapport avec votre projet ou des analogies avec la vie courante permet de mieux convaincre votre auditoire.
