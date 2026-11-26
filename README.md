# TP Héritage C# | KonoSekai

**Projet personnel de programmation orientée objet (POO) en C#**, commencé pendant l'été 2026 et construit autour de l'univers original **KonoSekai**.

L'objectif de ce TP est de transformer des personnages de fiction en objets C#, puis de faire interagir ces objets dans une application console : héritage, listes, associations, combats, transformations, polymorphisme et gestion des erreurs.

> **État du projet : prototype pédagogique en évolution.** Plusieurs mécaniques existent dans les classes, mais ne sont pas encore accessibles depuis le menu console. Certaines parties sont incomplètes ou nécessitent des corrections.

## Sommaire

- [L'univers KonoSekai](#lunivers-konosekai)
- [Objectifs pédagogiques](#objectifs-pédagogiques)
- [Fonctionnement du programme](#fonctionnement-du-programme)
- [Diagrammes de cas d'utilisation](#diagrammes-de-cas-dutilisation)
- [Diagramme de classes](#diagramme-de-classes)
- [Exemples de mécaniques C#](#exemples-de-mécaniques-c)
- [Installation et exécution](#installation-et-exécution)
- [État actuel et pistes d'amélioration](#état-actuel-et-pistes-damélioration)

## L'univers KonoSekai

**KonoSekai** est un univers de fiction original qui réunit des personnages aux pouvoirs élémentaires, célestes et temporels. Les liens familiaux, les alliances et les relations entre personnages sont aussi importants que les capacités de combat.

Quelques protagonistes donnent son identité au TP :

| Personnage | Place dans l'univers | Rôle dans le projet C# |
| --- | --- | --- |
| **Eto** | Père de Célestia, Stella et Akari ; partenaire d'Amé | Personnage spécialisé, combos familiaux et techniques |
| **Amé (Amélie)** | Mère des trois filles ; maîtrise des capacités temporelles | Mode Céleste, association avec ses filles, combo avec Eto |
| **Célestia** | Fille aînée d'Eto et d'Amé | Z Advanced, gestion d'alliés, perte de contrôle et attaques spécialisées |
| **Stella** | Deuxième fille de la famille | Z Advanced, attaques spéciales et combos avec Solar |
| **Akari** | Benjamine de la famille | Classe spécialisée héritant de FilleDuTemps |
| **Rairyu** | Proche de Célestia depuis l'enfance | Fusion foudroyante et interactions avec Célestia |
| **Umi** | Mère de Rairyu et Mizuki dans l'univers | Transformation Eau des Abysses, héritage FilleDuTemps |
| **Solar** | Partenaire de Stella | Vérification de combos et associations entre personnages |
| **Gobelins** | Adversaires destinés aux affrontements | Ennemis, numérotation et variante BossGobelin |

**À distinguer :** les relations de l'univers servent de contexte narratif ; une relation familiale n'implique pas un héritage entre classes C#. Les valeurs et âges écrits dans certains constructeurs correspondent à une version du TP et ne constituent pas nécessairement la chronologie actuelle de l'univers.

## Objectifs pédagogiques

Ce TP permet de mettre en pratique les notions suivantes :

| Notion de POO / C# | Mise en application dans le dépôt |
| --- | --- |
| **Classes et objets** | Personnage, technique, Dialogue, Gobelin… |
| **Constructeurs** | Initialiser les statistiques de chaque personnage |
| **Encapsulation** | Attributs privés ou protégés et méthodes publiques |
| **Héritage** | FilleDuTemps hérite de Personnage ; Celestia hérite de FilleDuTemps |
| **Polymorphisme** | Redéfinitions de méthodes virtuelles, notamment AttaqueNormal et ActiverModeCeleste |
| **Associations** | Listes d'alliés et de techniques, liens entre personnages |
| **Collections génériques** | List<Personnage>, List<technique>, List<Dialogue> |
| **Membres statiques** | Numéro unique attribué à chaque Personnage via DernierNumero |
| **Exceptions personnalisées** | KonoEvenementException, EnergieInsuffisante, TechniqueException, etc. |
| **Conditions et boucles** | Menu, choix de personnages, tours de combat et validations de saisie |

Le projet reprend l'idée d'un TP de gestion d'objets (comptes, opérations, restrictions) pour l'appliquer à un domaine plus concret et personnel : des personnages et des combats.

## Fonctionnement du programme

Le point d'entrée est **Program.cs**. Le menu console propose notamment :

1. **Choisir ou changer de personnage** parmi les personnages proposés.
2. **Construire des personnages**, en saisissant leur nom et leur âge.
3. **Afficher les informations** des personnages créés.
4. **Préparer un affrontement contre des gobelins** et sélectionner une cible à attaquer.
5. **Quitter l'application**.

Le programme met aussi en place des listes de personnages et d'ennemis. Plusieurs parcours restent expérimentaux : les soins depuis le menu ne sont pas implémentés, le choix de liste est incomplet et le combat contre un boss apparaît comme une option à développer.

Les méthodes de transformation ou de combo décrites ci-dessous existent surtout au **niveau des classes C#**. Elles ne doivent pas être confondues avec des fonctionnalités toutes accessibles dans l'interface console.

## Diagrammes de cas d'utilisation

Les schémas suivants représentent les **cas d'utilisation du TP** avec Mermaid, un format lisible directement dans les README GitHub et GitLab. Les cas à terminer sont identifiés explicitement.

### 1. Parcours de l'utilisateur dans la console

~~~mermaid
flowchart LR
    U["Utilisateur de la console"]
    subgraph APP["Application console KonoSekai"]
        A(["Choisir un personnage"])
        B(["Créer des personnages"])
        C(["Afficher nom et âge"])
        D(["Préparer un combat"])
        E(["Choisir un gobelin et attaquer"])
        F(["Constater la victoire"])
        G(["Soigner un allié : à terminer"])
        H(["Affronter le boss : à terminer"])
    end
    U --- A
    U --- B
    U --- D
    B -.-> C
    D -.-> E
    E -.-> F
    D -.-> G
    D -.-> H
    classDef todo fill:#fff4e6,stroke:#c27a17,color:#70420a,stroke-dasharray:5 5
    class G,H todo
~~~

**Lecture :** l'acteur est l'utilisateur qui interagit avec le menu. Les ellipses indiquent les actions étudiées. Les cases en pointillés signalent des parcours non finalisés ; ce dessin ne prétend pas que l'ensemble du menu fonctionne sans erreur.

### 2. Capacités du modèle objet, testables en C#

~~~mermaid
flowchart LR
    D["Développeur / testeur du TP"]
    subgraph MODEL["Classes métier du projet"]
        P(["Créer un objet Personnage"])
        T(["Ajouter ou utiliser une technique"])
        EN(["Contrôler le coût en énergie"])
        DEG(["Infliger des dégâts et détecter un KO"])
        TRANS(["Activer une transformation"])
        COMBO(["Déclencher un combo entre alliés"])
        ASSOC(["Associer des personnages"])
        EX(["Lever une exception métier"])
    end
    D --- P
    D --- T
    D --- TRANS
    D --- COMBO
    D --- ASSOC
    T -.-> EN
    T -.-> DEG
    TRANS -.-> EN
    COMBO -.-> EN
    EN -.-> EX
~~~

Ce deuxième schéma montre les comportements que les classes cherchent à modéliser. Il s'agit de **cas de test et d'apprentissage POO**, pas d'un deuxième écran de l'application.

## Diagramme de classes

Diagramme **simplifié d'après les fichiers présents sur la branche main**, et non d'après un ancien UML théorique du TP :

~~~mermaid
classDiagram
    class Personnage {
        -int age
        #string nom
        #int Energie
        #int PointDeVie
        -static int DernierNumero
        -int Numero
        +GetNumero() int
        +AjouterTechnique(technique)
        +UtiliserTechnique(nomTechnique, cible)
        +RecevoirDegat(degat)
        +AttaqueNormal(cible)
        +EstKo() bool
        +PeutParticiperCombo(nom, partenaire) bool
    }
    class FilleDuTemps {
        #bool ModeCelesteEstActif
        +ActiverModeCeleste()
        +DesactiverModeCeleste()
        +EstEnModeCeleste() bool
    }
    class Celestia {
        -bool EstEnZadavanced
        -bool PerteDeControl
        -List~Personnage~ allie
        +ActiverZadvanced()
        +AjoutAllie(allie)
        +ReprendreControle(rairyu)
    }
    class Ame {
        -int NbActivation
        +ActiverModeCeleste()
        +ValseEnflamee(eto, cible)
        +lierEnfant(c, s, a)
    }
    class Eto {
        +PeutParticiperCombo(nom, partenaire) bool
        +ComboFamille(famille) technique
    }
    class Stella {
        +Zadvanced()
        +EnchainementDynamique(solar, ennemi)
    }
    class Rairyu {
        +FusionFoudroyante()
        +CalmerCelestia(celestia)
    }
    class Umi {
        +ActiveEaudesAbysse()
    }
    class technique {
        -string nom
        -int coutEnergie
        -int Degat
        +GetNom() string
        +GetCoutEnergie() int
        +GetDegat() int
    }
    class Gobelin
    class BossGobelin
    class Akari
    class Solar
    class Dialogue
    class KonoEvenementException
    class EnergieInsuffisante
    class TechniqueException

    Personnage <|-- FilleDuTemps
    Personnage <|-- Eto
    Personnage <|-- Rairyu
    Personnage <|-- Solar
    Personnage <|-- Gobelin
    Gobelin <|-- BossGobelin
    FilleDuTemps <|-- Celestia
    FilleDuTemps <|-- Ame
    FilleDuTemps <|-- Stella
    FilleDuTemps <|-- Akari
    FilleDuTemps <|-- Umi
    Personnage "1" o-- "0..*" technique : repertoire
    Celestia "1" --> "0..*" Personnage : allies
    Ame --> Celestia : mere
    Ame --> Stella : mere
    Ame --> Akari : mere
    Stella --> Solar : partenaire
    Rairyu --> Celestia : interaction
    KonoEvenementException <|-- EnergieInsuffisante
    KonoEvenementException <|-- TechniqueException
~~~

**Différence importante avec la première conception :** dans le dépôt actuel, **Personnage n'est pas une classe abstract** et **Umi hérite de FilleDuTemps**, qui hérite elle-même de Personnage. Le diagramme suit ce code réellement versionné. Les relations entre personnages ne sont pas des relations d'héritage.

## Exemples de mécaniques C#

### Numérotation automatique

Chaque création de **Personnage** incrémente le compteur statique **DernierNumero** et enregistre la valeur dans **Numero**. La méthode **GetNumero()** permet de retrouver l'identifiant de l'instance. Les gobelins ont également leur propre logique de génération de nom.

### Techniques et ressources

Un personnage peut posséder une collection de **technique**. Une technique contient un nom, un coût en énergie, des dégâts et une description. L'utilisation d'une technique cherche à vérifier l'énergie disponible avant d'appliquer ses effets.

### Héritage et transformations

**FilleDuTemps** spécialise **Personnage** avec le Mode Céleste. **Amé** redéfinit son activation avec un coût dépendant du nombre d'utilisations. **Célestia** possède une mécanique de Z Advanced et de perte de contrôle. **Stella**, **Rairyu** et **Umi** disposent aussi de méthodes propres à leurs capacités.

### Associations et combos

**Amé + Eto :** la méthode **ValseEnflamee** consomme de l'énergie chez les deux partenaires et inflige des dégâts à une cible, sous conditions.

**Stella + Solar :** des méthodes décrivent des enchaînements de combat utilisant le partenaire.

**Célestia + Rairyu :** des interactions tentent de gérer le retour au calme après une perte de contrôle.

Ces méthodes servent à étudier les **associations entre objets** : collaborer avec un autre personnage ne veut pas dire hériter de sa classe.

### Exceptions métiers

Le programme définit une exception commune **KonoEvenementException** et plusieurs types spécifiques, notamment **AmeException**, **EtoException**, **CelestiaException**, **EnergieInsuffisante** et **TechniqueException**. Elles permettent de signaler des situations interdites, comme un manque d'énergie ou une action impossible. **StellaException** hérite actuellement directement de **Exception** et constitue un cas à harmoniser.

## Installation et exécution

### Prérequis

- **SDK .NET 10** (cible du fichier tpheritage.csproj).
- Un terminal et, au choix, Visual Studio, VS Code ou un autre éditeur C#.
- Une restauration NuGet pour les dépendances déclarées, dont **MySqlConnector 2.6.1**.

### Depuis GitHub

~~~bash
git clone https://github.com/etowarudsama95-stack/tpkonosekai-heritage1.git
cd tpkonosekai-heritage1
dotnet restore
dotnet run
~~~

Le même projet est également conservé sur [GitLab (Portfolio 2027)](https://gitlab.com/portfolio-simon-zacharie-2026/tpkonosekai-heritage1).

> Les commandes indiquent la procédure standard d'un projet console .NET. L'exécution complète de cette version n'a pas été validée dans le cadre de la rédaction de ce README. Le fichier bdd.cs est une ébauche de configuration ; aucune base de données active n'est nécessaire pour comprendre les objectifs POO du TP.

## État actuel et pistes d'amélioration

| Domaine | État visible dans le dépôt |
| --- | --- |
| Classes de personnages et héritage | Présents |
| Identifiants via compteur statique | Présents |
| Techniques, dégâts, énergie et exceptions | Méthodes présentes, tests à consolider |
| Menu et création de personnages | Présents, à fiabiliser |
| Combat contre des gobelins | Parcours partiellement codé |
| Soins depuis la console | Option affichée, non implémentée |
| Affrontement BossGobelin | Classe présente, parcours console à compléter |
| Transformations et combos | Méthodes présentes, intégration et corrections à poursuivre |
| Relations entre personnages | Associations présentes, initialisation à vérifier |

**Points techniques repérés pour la suite :**

- Initialiser les collections et objets utilisés avant d'y accéder, notamment certaines listes de Célestia.
- Vérifier les conditions de transformation, les calculs de ressources et les méthodes qui lancent encore **NotImplementedException**.
- Terminer les parcours du menu et gérer les choix invalides sans provoquer d'erreurs.
- Écrire des tests sur les dégâts, l'énergie, les KO, les combos et les exceptions.
- Harmoniser les exceptions personnalisées et distinguer les données de fiction des paramètres de combat.

## Contexte du projet

Projet d'entraînement **BTS SIO, option SLAM**, utilisé pour progresser en C#, UML et programmation orientée objet. Cette documentation décrit le travail réellement engagé et les prochaines étapes, sans présenter le prototype comme un jeu achevé.

**Dépôts :** [GitHub](https://github.com/etowarudsama95-stack/tpkonosekai-heritage1) · [GitLab](https://gitlab.com/portfolio-simon-zacharie-2026/tpkonosekai-heritage1)
