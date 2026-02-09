# MyEduSpace
<p align="center">
  <img src="https://github.com/user-attachments/assets/92d17eb7-6313-49cf-9526-7e049330813e" alt="LogoMyEduSpace" width="500"/>
</p>

**MyEduSpace** è un progetto open-source sviluppato in **Unity3D** per la realizzazione di un **ambiente virtuale immersivo e collaborativo** dedicato all’educazione e alla formazione.

La piattaforma consente a docenti e studenti di incontrarsi in un’aula virtuale 3D, interagire in tempo reale e sperimentare nuove modalità di didattica in un contesto immersivo.

---

## Descrizione della Piattaforma

MyEduSpace è un **Virtual Learning Environment** progettato per supportare diverse  metodologie didattiche.

### Funzionalità principali

- **Sistema di stanze**  
  Connessione in tempo reale con altri utenti tramite la creazione o l’accesso a stanze condivise.

- **Esplorazione 3D dell’ambiente**  
  Movimento libero all’interno dell’aula virtuale: camminare, sedersi, ruotare la visuale e interagire con gli oggetti presenti nella scena.

- **Avatar e presenza virtuale**  
  Ogni utente è rappresentato da un avatar a mezzo busto visibile agli altri partecipanti.

- **Comunicazione vocale**  
  Chat vocale con audio spaziale 3D per una comunicazione più realistica.

- **Chat testuale**  
  Sistema di messaggistica testuale integrato nell’interfaccia.

- **Proiezione di contenuti multimediali**  
  Visualizzazione di contenuti tramite l'utilizzo di un proiettore

- **Lavagna condivisa**  
  Scrittura e disegno su una lavagna virtuale.
  
- **Personalizzazione aule**  
  Possibilta di personalizzare le aule partendo da un aula vuota oppure da un template

<p align="center">
  <img src="https://github.com/user-attachments/assets/adfd7345-9aee-47e9-8b2e-bf26114ac119" alt="BannerLezioneFrontale" height="160"/>
  <img src="https://github.com/user-attachments/assets/88c6d1be-c449-4cfa-8efb-da02706dea73" alt="BannerLezioneDiGruppo" height="160"/>
  <img src="https://github.com/user-attachments/assets/f50766c4-78e3-4181-b3d2-5fae83da6f1c" alt="BannerLezioneCircleTime" height="160"/>
</p>

---

## Contenuto del Repository

Questo repository contiene:

- **Progetto Unity**  
  Il progetto Unity completo, comprensivo di scene, script e asset.

- **Build macOS**  
  Versione compilata dell’applicazione pronta all’uso su macOS Apple Silicon, disponibile nella sezione *Releases*.

- **Build Windows**  
  Versione compilata dell’applicazione pronta all’uso su Windows 64-bit, disponibile nella sezione *Releases*.

---

## Installazione

È possibile utilizzare MyEduSpace in due modi:
- eseguendo una **build precompilata**
- aprendo il **progetto Unity** per sviluppo o modifica

---

### Utilizzo dell’Applicazione 

#### macOS

1. Scaricare il file ZIP della build macOS dalla sezione **Releases**.
2. Estrarre il contenuto in una cartella.
3. Al primo avvio, macOS potrebbe bloccare l’applicazione perché non firmata.

Per avviare l’applicazione:
- Andare in Impostazioni di Sistema -> Privacy e Sicurezza
- Autorizzare apertura dell'apllicazione

In alternativa, da terminale:
```bash
xattr -dr com.apple.quarantine MyEduSpaceVR.app
```
### Windows

1. Scaricare il file ZIP della build Windows dalla sezione **Releases**.
2. Estrarre il contenuto in una cartella.
3. Avviare il file `MyEduSpace.exe.

### Utilizzo del Progetto Unity

#### Requisiti

- **Unity Hub**
- **Unity 6**

#### Passaggi

1. Clonare o scaricare il repository.
2. Aprire **Unity Hub**.
3. Andare nella sezione **Projects** e cliccare su **Add**.
4. Selezionare la cartella del progetto **MyEduSpace**.
5. Aprire il progetto: Unity provvederà automaticamente a installare i pacchetti necessari.
6. Una volta aperto il progetto, è possibile avviare l’applicazione in **Play Mode** o generare nuove build.

