##### STEP CREAZIONE STANZA CON PRIMITIVE



1. Creato un GameObject vuoto "Environment" dove inserire la tutta struttura statica
2. Creato un GameObject vuoto "Room" che funge da contenitore per i prefab della stanza
3. Creata la cartella Prefab dove inserire tutti i prefab utilizzati per creare la stanza
4. Suddivisa la room con 4 GameObject diversi per indicare pareti, pavimento, tetto e oggetti
5. Inserito un oggetto vuoto in scena chiamato "WallVariant1"
6. Creato il suo prefab, trascinandolo nella cartella "Prefab"
7. Entrato nella modifica del prefab "WallVariant1"
8. Se non settato, mettere la position a 0,0,0 in modo da impostare il pivot correttamente
9. Creato un piccolo plane per centrare il vertice dell'oggetto 3D
10. Creato un cubo 3D per il muro, modellato usando la shortcut T (Rect Tool)
11. Finito di modellare, elimino il plane ed esco dal prefab
12. inserito il prefab come figlio del GameObject "Walls"
13. Aumentare l'altezza della stanza (Transform Y del prefab padre)
14. Duplicati i prefab e allineati l'uno all'altro sfruttando la shortcut V per attaccare i vertici
15. Per il pavimento e per il tetto si potrebbero creare prefab dedicati, ma per velocizzare il processo bastano 2 plane
    modellati in base alla superficie della stanza
16. Dal GameObject "Floors" si crea un plane e si modella
17. Duplicato il plane floor, rinominato "roof" ruotato e posizionato come tetto della stanza
18. Per i props fatto un tavolo utilizzando i cubi (Stesso procedimento dei wall)
19. Creazione di un props (asse di legno) da posizionare in giro per la stanza (prefab)
20. posizionare alcune assi di legno nella stanza
21. Creazione cartella "Material" per materiali
22. Creazione materiale per assi di legno
23. Assegna il materiale al prefab delle assi
24. Creazione di altri materiali di prova da assegnare agli altri oggetti in scena (pavimento, tavolo, ecc.)
25. Posizionare una PointLight per simulare una luce in stanza e spegnere la directional



##### TIPS UTILI



* Per una migliore suddivisione della scena di gioco, ho preferito inserire tutti gli oggetti considerati *statici* in un
  GameObject padre chiamato "Environment", inoltre cosi facendo si e' possibile attivare il flag static su tutti gli oggetti figli
  in un unica volta
* Ho preferito creare prefab dei singoli muri, pavimenti ecc. in modo tale da poter applicare una sola volta lo stile
  (material ecc.) e applicarlo a tutti gli oggetti collegati al prefab
* Per creare prefab dei muri, pavimenti ecc. ho preferito creare il prefab da un GameObject vuoto. In questo modo posso impostare il pivot del prefab su un vertice del muro o pavimento o l'oggetto in questione
* Per allineare un vertice del cubo al pivot, si crea temporaneamente un piccolo plane di dimensione 0.1 che faccia da "ancora"
  per il vertice dell'oggetto 3D
* Attenzione: quando si posizionano i muri figli di un game object vuoto, il trasform del prefab fara riferimento al padre. dunque quando si modella, utilizzare il transform del padre
