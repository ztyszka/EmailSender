

## Wyb�r technologii:
- **SqLite** - potrzeba niewielkiej bazy danych, �atwej do przeniesienia wraz z kodem i wykorzystania na innym urz�dzeniu
- **Dapper** - bo zna�am, prawdopodobnie wygodniej by by�o zastosowa� EF, ale z mojej perspektywy wyd�u�y�oby to czas pracy nad projektem, a zale�y mi na jak najszybszym dostarczeniu rozwi�zania;
	dzi�ki EF zmiany w bazie danych wykonywa�yby si� automatycznie w formie transakcji, Dapper tego nie zapewnia, dlatego dzia�ania sk�adaj�ce si� z wi�cej ni� jednego etapu (np. usuni�cie kontaktu) opakowa�am w transakcje
- **MailKit** - biblioteczka rekomendowana przez Microsoft, wykorzysta�am swoje Google Workspace aby nie musie� tworzy� nowego serwera SMTP (co jednak by�oby konieczne przy rozwi�zaniach produkcyjnych) 


## Dalszy rozw�j:
### Frontend
- po klikni�ciu przycisku "Delete" wy�wietli� okno z potwierdzeniem operacji
- na widoku kontakt�w doda� scrollbar, dzi�ki kt�remu przewijana jest tylko lista
- rozwa�y� paginacj� list kontakt�w - przydatne w przypadku du�ej liczby rekord�w w bazie danych, �eby nie musie� od razu zaci�ga� wszystkiego
- w widoku szczeg��w kontaktu doda� mo�liwo�� usuni�cia kontaktu z grupy - przycisk "x"" na ka�dej z grup w tym widoku
- w widoku szczeg��w doda� mo�liwo�� dodania kontaktu do nowej grupy - przycisk "+", co umo�liwi dodanie kontaktu do istniej�cej lub nowoutworzonej grupy - dropdown z mo�liwo�ci� dodania w�asnego tekstu
- wy�rodkowanie element�w w widoku kontakt�w - zajmowa�o mi du�o czasu i zostawi�am na p�niej
- nowy kontakt / edycja kontaktu - rozwa�a�am zrobienie ich poprzez popup albo formularze "wbudowane" w widok listy, tj. pierwszy element listy by�by formularzem dodawania nowego kontaktu, a po klikni�ciu przycisku "Edit" dany element listy zmienia�by si� na formularz do edycji

### Backend
- w przypadku wykorzystania aplikacji do wysy�ania maili do bardzo du�ych grup kontakt�w istnieje ryzyko, �e bulk send nie zadzia�a (mo�e mie� ukryte limity przeciwspamowe), dlatego mo�na rozwa�y� u�ycie puli w�tk�w dzia�aj�cych w tle i wysy�aj�cych maile partiami / pojedynczo
- 