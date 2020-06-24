# Digitalna ribarnica
Digitalna ribarnica je projekt zamišljen kao aplikacija koja omogućava trgovcima ribe dnevno postavljanje ponude riba u kojoj navode količinu, cijenu, lokaciju i ostale elemente ponude. Korisnik aplikacije (kupac) može odabrati lokaciju i pretražiti različite vrste ribe te rezervirati količinu ribe. Unutar aplikacije izrađen je sustav obavijesti i razmjene poruka koji olakšava komunikaciju između trgovca i kupca.

## Projektni tim

Ime i prezime  | E-mail adresa (FOI) | JMBAG      | Github korisničko ime
-------------- | ------------------- | ---------- | ---------------------
Božo Kvesić    | bkvesic@foi.hr      | 0016129614 | BozoKvesic
Nikola Muše    | nmuse@foi.hr        | 0016131266 | nmuse-foi
Anabela Pranjić| apranjic@foi.hr     | 0016129747 | apranjic25

## Opis domene
Digitalna ribarnica je namijenjena svakome tko želi prodat ili kupiti ribu. Olakšava trgovanje ponuditeljima na način da jednostavno sastave ponudu unutar aplikacije gdje navode osnove podatke ponude poput vrste ribe, lokacije, cijene, količine, opisa i trajanja rezervacije te mogu prihvaćati ili odbijati rezervacije ostalih korisnika aplikacije. Razvijen je i sustav komunikacije koji omogućava razmjenu poruka između kupca i ponuditelja kako bi mogli dogovoriti prodaju. Sustav obavijesti korisniku daje uvid u razne obavijesti poput zahtjeva za rezervacijom ponude, prihvaćenom rezervacijom, dobivenom porukom te ostalim sustavskim obavijestima. Korisnici se mogu međusobno ocjenjivati nakon provedene transakcije, ostavljati komentare te dobivati značke.

## Specifikacija projekta
Sljedeća tablica prikazuje funkcionalnosti koje je potrebno implementirati uz kratki opis te pridruženog člana tima koji je odgovoran za izradu navedene funkcionalnosti.

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija korisnika | Korisnik predstavlja kupca ili ponuditelja koji preko forme za registraciju unosi osobne podatke: ime, prezime, email adresu, korisničko ime, broj telefona, mjesto, datum rođenja te lozinku i potvrdu lozinke. Administrator potvrđuje registraciju. | Božo Kvesić, Anabela Pranjić
F02 | Prijava korisnika | Prijava u aplikaciju se odvija preko forme za prijavu koja zahtijeva unos korisničkog imena ili email adrese te pripadne lozinke. Nakon prijave u aplikaciju, korisniku se otvara sučelje aplikacije primjereno njegovoj ulozi (Administrator/Ponuditelj/Kupac). U formi prijave postoji i poveznica „Zaboravljena lozinka“ koja omogućava ponovno postavljanje lozinke u slučaju da je korisnik istu zaboravio. | Božo Kvesić
F03 | Administracija korisnika | Funkcionalnost je namijenjena administratoru te je uključena u njegovo sučelje. Odnosi se na dodavanje novih korisnika, blokiranje i deblokiranje korisnika. | Božo Kvesić
F04 | Pregledavanje ponuda | Sve uloge mogu pretraživati i filtrirati ponude. Ponude su vidljive na početnoj stranici aplikacije. | Anabela Pranjić
F05 | Dodavanje ocjene za korisnika | Registrirani korisnik može dodati ocjenu za ponuditelja nakon što kupi nešto od njega ali i ponuditelj može ocijeniti kupca. | Anabela Pranjić, Nikola Muše
F06 | Rezerviranje ponude | Registrirani korisnik može rezervirati ponudu koju onda ponuditelj može prihvatiti ili odbiti. Ponuditelj određuje vremenski rok, ali postoji predefinirano (default) vrijeme za rezervaciju od 30 minuta. | Božo Kvesić
F07 | Potvrđivanje rezervacije | Ponuditelj mora unutar tih 30 minuta (ili više ako je to ponuditelj odredio) prihvatiti rezervaciju ili ona propada. | Nikola Muše
F08 | Kontaktiranje ponuditelja | Registrirani korisnik može kontaktirati ponuditelja. | Božo Kvesić, Nikola Muše
F09 | Promjena predefiniranih postavki | Administrator može mijenjati neke postavke koje su već sustavom definirane (minimalna količina, minimalna cijena). | Nikola Muše
F10 | Administracija ponude ribe | Administrator može administrirati ponudu ribe (vrsta, količina, cijena, lokacija). Uređivanje i brisanje ponude. | Nikola Muše, Božo Kvesić
F11 | Dodavanje kontakt podataka | Ponuditelj može dodati kontakt podatke - broj telefona ili mu se po defaultu postavlja broj telefona kojeg je unio prilikom registracije. | Nikola Muše
F12 | Dodavanje nove ribe i novih lokacija | Administrator može dodavati fotografije i lokacije ribe. | Nikola Muše
F13 | Dodavanje i administracija ponude | Ponuditelj može dodati ponudu u kojoj navodi količinu, cijenu, vrstu ribe, lokaciju te po potrebi opis, dodatnu fotografiju i trajanje rezervacije. Ponuditelj nakon dodavanja ponude može ju naknadno uređivati i brisati. | Anabela Pranjić
F14 | Pregled izvršenih rezervacija | Ponuditelj i kupac mogu pregledati izvršene rezervacije. | Božo Kvesić, Anabela Pranjić
F15 | Slanje obavijesti ponuditelju | Sustav može poslati ponuditelju obavijest o rezervaciji koje se vide unutar aplikacije. Ako se obavijest ne pročita unutar 30 minuta od slanja, ponuditelj istu obavijest dobiva na mail. | Božo Kvesić
F16 | Promjena količine dostupne ribe | Sustav mijenja količinu ribe u ponudi ukoliko ponuditelj odobri rezervaciju. | Anabela Pranjić
F17 | Potvrđivanje preuzimanja ribe | Ponuditelj potvrđuje da je kupac preuzeo ribu. | Anabela Pranjić
F18 | Značke | Sustav dodjeljuje značke ovisno o povijesti kupnje i prodaje kako bi nagradila vjernost kupca i pouzdanost ponuditelja. | Nikola Muše, Anabela Pranjić
F19 | Pregled dnevnika | Administrator nakon prijave u aplikaciju ima uvid u radnje zabilježene u dnevniku. | Nikola Muše, Božo Kvesić
F20 | Korisničke upute | Unutar aplikacije se nalaze upute za korištenje aplikacije kojima se pristupa pritiskom tipke F1 ili odabirom opcije za pomoć. | Anabela Pranjić
F21 | Povezivanje na bazu podataka | Baza podataka sadrži korisničke podatke, podatke o ponudama, ribama, lokacijama, rezervacijama, dnevniku rada, ocjenama, značkama i obavijestima. Aplikacija se povezuje na bazu podataka u koju upisuje podatke preuzete iz korisničkog sučelja te preuzima podatke potrebne za popunjavanje ponude poput predefiniranih vrsta riba i lokacija, uloga korisnika i sl. Navedena funkcionalnost zapravo povezuje gotovo sve gore navedene funkcionalnosti. | Nikola Muše, Božo Kvesić, Anabela Pranjić

## Tehnologije i oprema
Za izradu projekta korišteni su brojni alati poput MS Office paketa za oblikovanje dokumenata i tablica čiji je sadržaj potom uređen putem GitHub Wiki sustava. Nadalje, korišten je online alat Visual Paradigm za kreiranje UML dijagrama, Microsoft Project za izradu terminskog plana projekta i gantograma. Za izradu ERA modela korišten je MySQL Workbench te SQL Server Management Studio za izradu baze podataka. Implementacija je odrađena u programskom jeziku C#, u alatu Microsoft Visual Studio. Wireframe aplikacije je izrađen u online alatu Balsamiq. Kako bi kreirali i oblikovali logo aplikacije, koristili smo alate Adobe Illustrator i Adobe Photoshop koristeći besplatnu probnu verziju. Za neke alate imamo licence koje smo dobili tijekom školovanja, dok za pojedine alate nije bila potrebna licenca.
