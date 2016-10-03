# E-AvropArbetsprov   
   
####Beskrivning    
#####Denna uppgift går ut på att hämta data via HTTP som sedan ska tolkas och utföras vissa beräkningar på. Urlen till datakällan
är https://www.poromaa.com/assignment_data/transactions.json. Datan är väldigt enkel och representerar balansförändringar på
ett konto för diverse kunder. Datan kan ses som en ström av uppdateringar som börjar vid den senaste utförda och går bakåt i
tiden där varje uppdatering är separerat med newline. En uppdatering kan t.ex. se ut som nedan:
{"customer":"Ventohow","transaction":20776.84,"date":"2016-09-27T15:09:31.5251805+02:00"}
Fälten beskriver i ordning, namnet på kontot, balansförändringen (kan vara både positiv och negativ), samt tidpunkten när
uppdateringen skedde.
   
Din uppgift är att konstruera en console applikation i C#, .net version 4.5.* eller Core 1.0.*. Denna applikation ska ta två
parametrar som indata, ett namn på ett konto och en specifik månad angiven på formatet YYYY-MM (ex. 2015-05). Applikationen
ska sedan skriva ut en rad på formatet "Balance: {balance}", där {balance} är den aggregerade balansförändringen för det
angivna kontot och månaden.
