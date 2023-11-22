# Presentation
- Le dossier Vue contient le front et le dossier dotnet le back
- Pour pouvoir acceder a l'API externe, il faut que le navigateur soit configure a accepter les cors pour localhost

# Installation
## Front (VSCODE)
- lancer la commande npm install ou yarn correspondant pour installer les dependances
- configurer un fichier .env pour avoir les variables suivants
  - VITE_DOTNET_API_URL=serveur local backend
  - VITE_EXTERNAL_API=http://www.zefix.admin.ch/ZefixPublicREST
  - VITE_EXTERNAL_API_USERNAME=nom d'utilisateur api externe
  - VITE_EXTERNAL_API_PASSWORD=mot de passe api externe
- Lancer avec npm run dev

## Back (VISUAL STUDIO)
- Creer une solution web et y installer le repo
- Installer EFcore design et sqlite
- Installer Sqlite
- lancer la commande update-database dans la console package manager pour creer la base de donnees
- Lancer le projet
