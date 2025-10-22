##### STEP PLAYER CON INPUT SYSTEM (OLD AND NEW)



1. Creazione di un prefab "PlayerOldInput" e "PlayerNewInput" utilizzando una capsula
2. Sposto la MainCamera come figlia del Player per la visuale in prima persona
3. Posiziono la Camera in altezza muovendola sull'asse Y
4. Aggiungo il componente "CharacterController" al player
5. Assegno il tag "Player" al prefab del player
6. Assegno al floor il layer ground, servira' successivamente per implementare il salto
7. Creazione dello script PlayerControllerOld per il vecchio input system
8. Assegno al PlayerOldInput lo script appena creato
9. Implemento le meccaniche di movimento salto e rotazione camera
10. Per il nuovo Input System unity mette gia' a disposizione un biding di tasti predefinito, se non c'e' tempo
    si puo' utilizzare quello, altrimenti si cancella e si seguono gli step per la creazione dell'input system



##### TIPS UTILI



* Ho preferito differenziare due prefab differenti per far vedere la differenza tra i due input system
* Ho aggiunto ora il tag player al prefab del player e ground



##### STEP CREAZIONE NUOVO INPUT SYSTEM



1. Package: assicurati di avere installato “Input System” (Window → Package Manager).
2. Project Settings → Player → Active Input Handling: metti Both (o Input System Package).
3. Crea un Input Actions nella cartella asset (tasto destro -> Create ->  Input Action)
4. Crea una ActionMap (+ -> dai nome all'action map) e aggiungi azioni:
   	Move (type: Value / Vector2), + -> "Add Up/Down/Left/Right Composite".
   		Bindings: Keyboard -> Up=W, Down=S, Left=A, Right=D
   	Jump (type: Button), + -> "add Biding"
   		Bindings: Keyboard → Space
   	Look (type: Value / Vector2), + -> "add Biding"
   		Biding: Mouse -> Delta
5. Salva la Action Map con il pulsante Save Asset
6. Nell'ispector di "Player.InputActions" flagga il checkbox "Generate C# Class" e poi il pulsante Apply
7. Se da errore cambia il nome alla classe generata
8. Apri script PlayerNewInput e crea meccaniche di movimento, salto e rotazione
