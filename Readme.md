

## Wybór technologii:
- **SqLite** - potrzeba niewielkiej bazy danych, ³atwej do przeniesienia wraz z kodem i wykorzystania na innym urz¹dzeniu
- **Dapper** - bo zna³am, prawdopodobnie wygodniej by by³o zastosowaæ EF, ale z mojej perspektywy wyd³u¿y³oby to czas pracy nad projektem, a zale¿y mi na jak najszybszym dostarczeniu rozwi¹zania;
	dziêki EF zmiany w bazie danych wykonywa³yby siê automatycznie w formie transakcji, Dapper tego nie zapewnia, dlatego dzia³ania sk³adaj¹ce siê z wiêcej ni¿ jednego etapu (np. usuniêcie kontaktu) opakowa³am w transakcje
- **MailKit** - biblioteczka rekomendowana przez Microsoft, wykorzysta³am swoje Google Workspace aby nie musieæ tworzyæ nowego serwera SMTP (co jednak by³oby konieczne przy rozwi¹zaniach produkcyjnych) 


## Dalszy rozwój:
### Frontend
- po klikniêciu przycisku "Delete" wyœwietliæ okno z potwierdzeniem operacji
- na widoku kontaktów dodaæ scrollbar, dziêki któremu przewijana jest tylko lista
- rozwa¿yæ paginacjê list kontaktów - przydatne w przypadku du¿ej liczby rekordów w bazie danych, ¿eby nie musieæ od razu zaci¹gaæ wszystkiego
- w widoku szczegó³ów kontaktu dodaæ mo¿liwoœæ usuniêcia kontaktu z grupy - przycisk "x"" na ka¿dej z grup w tym widoku
- w widoku szczegó³ów dodaæ mo¿liwoœæ dodania kontaktu do nowej grupy - przycisk "+", co umo¿liwi dodanie kontaktu do istniej¹cej lub nowoutworzonej grupy - dropdown z mo¿liwoœci¹ dodania w³asnego tekstu
- wyœrodkowanie elementów w widoku kontaktów - zajmowa³o mi du¿o czasu i zostawi³am na póŸniej
- nowy kontakt / edycja kontaktu - rozwa¿a³am zrobienie ich poprzez popup albo formularze "wbudowane" w widok listy, tj. pierwszy element listy by³by formularzem dodawania nowego kontaktu, a po klikniêciu przycisku "Edit" dany element listy zmienia³by siê na formularz do edycji

### Backend
- w przypadku wykorzystania aplikacji do wysy³ania maili do bardzo du¿ych grup kontaktów istnieje ryzyko, ¿e bulk send nie zadzia³a (mo¿e mieæ ukryte limity przeciwspamowe), dlatego mo¿na rozwa¿yæ u¿ycie puli w¹tków dzia³aj¹cych w tle i wysy³aj¹cych maile partiami / pojedynczo
- 