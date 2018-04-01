# WebService Project
## Extensions
- Monitoring
- GUI
- Asynchrone
- Cache

## Structure
Cette solution contient 4 projets
* Un Service Intermediaire SOAP qui consume le service REST de JCDecaux et qui expose un service SOAP pour récupérer des données de monitoring
* Un projet console qui permet de hoster la librairie du service intermediaire
* Un client WPF qui consumme le service SOAP intermediaire
* Un client WPF qui permet d'afficher les données du monitoring

## Lancement

Il faut lancer VelibIntermediaryHost pour pouvoir hoster la librairie VelibIntermediaryLibrary qui contient les services soap de monitoring et de connection à l'API JCDECAUX

Ensuite on peut lancer les clients.
Le client de Monitoring permet de récupérer le nombre de requetes lancées par les clients, et le nombre de requètes faites au serveur JCDecaux depuis les `X` dernières minutes. Aussi les noms des objets mis en cache par le webService