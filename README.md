Ομάδα InsOrAp:
	+ Comment: Λόγω λάθους συντονισμού και έλλειψης γνώσης στο git - github, αναγκαστήκαμε να διαγράψουμε το προηγούμενο repository και να δημιουργήσουμε νέο.
	
	+ Δομή Project:
		+ InsoramApp: Android application η οποία αποκτά τη θέση του κινητού και επικοινωνεί με το WebService της εκάστοτε ασφαλιστικής εταιρείας.
		+ InsOrApDesk: Εφαρμογή Windows desktop η οποία ενημερώνεται για ενδεχόμενα νέα ατυχήματα/προβλήματα
		+ InsOrService: Windows service (ACC) το οποίο αναλαμβάνει την αυτόματη διευθέτηση όλων των ατυχημάτων/προβλημάτων
		+ SQL Definition: Το definition της ΒΔ την οποία αναπτύξαμε (για τις αναγκές του testing)
		+ WebService: .NET WebService με το οποίο επικοινωνεί το android application (InsoramApp) 
		+ InsOrAp_pre_v2: Η .pptx παρουσίαση 
		
	+ APIs/Frameworks που χρησιμοποιήθηκαν:
		+ InsOrApDesk - APIs: Google Maps API, Google reverse geocoding | Framework: .NET 3.5
		+ InsoramApp - APIs: Google reverse geocoding, Google location services
		+ InsOrService - Framework: .NET 3.5 
		+ WebService - Framework: .NET 2.0