# ioDynGoogleUpdate

---

ioDynGoogleUpdate is desinged for when you purchase your domain from Goolgle ([Google Domain](https://domains.google.com/registrar/)) but do not have a static IP.
This will allow you to have 1 or many doomains redirected as needed. 

---

This application is desinged using vb.net creating a Window Service. <br />
<br />
Only requirment is .ini file with the following info and setup.. <br />
<br />
---

##MySites.ini (JSON)

[{"Domain":"mydomain.com","Username":"U1U1U1U1U1U!","Password":"P1P1P1P1P1P!","Interval":60}]<br />
<br />
where "mydomain.com"  - is the google purchased domain.<br />
where "U1U1U1U1U1U!"  - is the google provided encoded username.<br />
where "P1P1P1P1P1P!"  - is the google provided encoded password.<br />
where 60              - is the number of minutes interval between update. <br />
<br />

---

##Logfile.txt (text file)

The Text file reports actions and needed responses.. <br />
<br />
ie:<br />
5/10/2022 11:00:14 PM ** New File Start ** <br />
5/10/2022 11:00:14 PM > Started....<br />
5/10/2022 11:00:14 PM > Ini Doesnt Exist....<br />
5/10/2022 11:00:14 PM > Ini Created....<br />
5/10/2022 11:00:14 PM > Will wait for user to mod & estart....<br />
5/10/2022 11:00:14 PM > Stoppped....<br />
5/10/2022 11:01:24 PM > Started....<br />
5/10/2022 11:01:24 PM > Ini Read....<br />
5/10/2022 11:01:24 PM > Setting Dyn Domain :mydomain.com<br />
5/10/2022 11:01:25 PM > Response Dyn Domain : mydomain.com ----> nochg 000.000.000.000<br />
5/10/2022 11:01:25 PM > Starting Domain : mydomain.com timer.<br />
5/11/2022 12:01:24 AM > Timer : mydomain.com Tick!<br />
5/11/2022 12:01:24 AM > Setting Dyn Domain :mydomain.com<br />
5/11/2022 12:01:25 AM > Response Dyn Domain : mydomain.com ----> nochg 000.000.000.000<br />
5/11/2022 1:01:24 AM > Timer : mydomain.com Tick!<br />
.. etc<br />
<br />
