InsorApp (Android application)

Current Commit #1

+ Commit #1 (1/10/2016 - 17:41)
  + Προστέθηκαν:
    + Δημιουργία 2 βασικών management κλάσεων (SoapRequestManager & DataBaseManager - Διαχείρηση όλων των Soap request προς τον server & Διαχείρηση της λειτουργίας της βάσης δεδομένων (SQLite))
    + Δημιουργία κλάσεων για μεταφορά δεδομένων μεταξύ εφαρμογής και server.
    + Δημιουργία βοηθητικών management κλάσεων (AlertBuilder, ProgressDialog) 
    
  + Υλοιποιήθηκαν:
    + SplashScreen: activity (ελέγχει για credentials. Αν υπάρχουν -> mainScreen, αλλιώς -> signUp)
    + SignupScreen: activity για σύνδεση (once-off) με τον server
    + MainScreen: activity για επιλογή προβλήματος (Ατύχημα, Πυρκαγιά, Θραύση κρυστάλλων, Κλοπή)
  
  + Επόμενο commit:
    + Activity για ονομασία αυτοκινήτων
    + Activity για δήλωση ατυχημάτων 
    + Στόχος: Πριν τις 8
