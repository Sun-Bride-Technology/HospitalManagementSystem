USE HospitalManagementSystem;
GO

/*STATUS*/
INSERT INTO [SECURITY].[STATUS]
	VALUES('Current');
INSERT INTO [SECURITY].[STATUS]
	VALUES('Disabled');
INSERT INTO [SECURITY].[STATUS]
	VALUES('Removed');
	--PATIENT
INSERT INTO [SECURITY].[STATUS]
	VALUES('Admitted');
INSERT INTO [SECURITY].[STATUS]
	VALUES('Patient Discharge');
INSERT INTO [SECURITY].[STATUS]
	VALUES('Dead');

/*ROL*/
INSERT INTO [SECURITY].ROL
	VALUES('Administrator');
INSERT INTO [SECURITY].ROL
	VALUES('Receptionist');

/*JOB*/
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Anesthesiology and Resuscitation');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Cardiology');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Emergency Medicine');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Intensive Medicine');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Pneumology');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Neurology');
INSERT INTO HOSPITAL.JOB
	VALUES('Medical','Dermatology');
-- NURSING --
INSERT INTO HOSPITAL.JOB
	VALUES('Nursing','Obstetric-Gynecological');
INSERT INTO HOSPITAL.JOB
	VALUES('Nursing','Medical-Surgical Care');
INSERT INTO HOSPITAL.JOB
	VALUES('Nursing','Mental Health');
INSERT INTO HOSPITAL.JOB
	VALUES('Nursing','Pediatric');

/*EMPLOYEE*/
INSERT INTO HOSPITAL.EMPLOYEE
	VALUES(
		'Raúl Arturo',	--Name
		'Salomon',	--Last Name
		'Iglesias',	--Mother's Last Name
		'M',	--Gender
		'11-09-2001',	--Birth Date
		20,	--AGE
		'raul@gmail.com',	--Email
		'0987654321',	--Phone
		'San Nicolas #1109',	--Adsress
		6,	--Job
		1	--Status
	);

INSERT INTO HOSPITAL.EMPLOYEE
	VALUES(
		'Jana Alexandra',	--Name
		'Gutiérrez',	--Last Name
		'Campos',	--Mother's Last Name
		'F',	--Gender
		'10-25-2003',	--Birth Date
		18,	--AGE
		'jana@gmail.com',	--Email
		'1234567890',	--Phone
		'San Nicolas #1109',	--Adsress
		11,	--Job
		1	--Status
	);

/*User*/
	--Admin
INSERT INTO [SECURITY].[USER]
	VALUES (
		1,	--Id
		1,	--Rol
		1,	--Status
		'raul.sa@gmail.com',	--Email
		'f6f4a68ffee3946897fd98ace4798fd7c45d4d43d126199efc7069cc714a65b5'	--Password
	);

	--Receptionist
INSERT INTO [SECURITY].[USER]
	VALUES (
		3,	--Id
		2,	--Rol
		1,	--Status
		'jana.sa@gmail.com',	--Email
		'5770f02e63b2826240f856f6cf87050528feb569c05e5a7b65202da035fadbd1'	--Password
	);


/* PATIENT */
INSERT INTO HOSPITAL.PATIENT 
	VALUES(
		'RASI010911VERMEXZ1',
		'RAÚL ARTURO',
		'SALOMON',
		'IGLESIAS',
		'M',
		'2001-11-09',
		20,
		'1234567890',
		'CADEREYTA',
		4
	)
INSERT INTO HOSPITAL.PATIENT 
	VALUES(
		'PAH186218MTYMEXZ51',
		'PEDRO',
		'AGUILAR',
		'HERRERA',
		'M',
		'2001-11-09',
		21,
		'1234567890',
		'CADEREYTA',
		5
	)
INSERT INTO HOSPITAL.PATIENT 
	VALUES(
		'AJGC193397MTYMEXZ1',
		'ARANZA JAQUELINE',
		'GONZALEZ',
		'CASTILLO',
		'F',
		'2001-11-09',
		18,
		'1234567890',
		'APOCADA',
		16
	)

/* ALLOCATION */
INSERT INTO HOSPITAL.ALLOCATION
	VALUES(
		1,
		3,
		'A1-09',
		GETDATE(),
		NULL
	)
INSERT INTO HOSPITAL.ALLOCATION
	VALUES(
		2,
		1,
		'B1-01',
		'2022-04-29 15:20:11.613',
		'2022-04-29 17:33:11.613'
	)
INSERT INTO HOSPITAL.ALLOCATION
	VALUES(
		3,
		1,
		'A1-07',
		'2022-04-29 13:30:09.613',
		'2022-04-29 22:03:15.613'
	)


/* CONSULTATION */
INSERT INTO HOSPITAL.CONSULTATION
	VALUES(
		2,
		2,
		1,
		'2022-04-29 15:30:10.313',
		'GRIPE Y DOLOR DE CABEZA',
		'COVID-19',
		'PARACETAMOL'
	)

INSERT INTO HOSPITAL.CONSULTATION
	VALUES(
		2,
		2,
		3,
		'2022-04-29 16:15:52.113',
		'GRIPE Y DOLOR DE CABEZA',
		'RESFRIADO',
		'El paracetamol (Tylenol) y el ibuprofeno (Advil, Motrin)'
	)

INSERT INTO HOSPITAL.CONSULTATION
	VALUES(
		1,
		1,
		3,
		'2022-04-29 17:38:01.053',
		'Dolor generalmente en un lado de la cabeza, pero a menudo en ambos lados. Dolor que palpita o late. Sensibilidad a la luz, al sonido y, a veces, a los olores y al tacto. Náuseas y vómitos.',
		'MIGRAÑA',
		'Aspirina o el ibuprofeno (Advil, Motrin IB, otros) Y Sumatriptán (Imitrex, Tosymra), Rizatriptán (Maxalt, Maxalt-MLT)'
	)
SELECT * FROM SECURITY.ROL;
SELECT * FROM SECURITY.STATUS;
SELECT * FROM HOSPITAL.JOB;

SELECT * FROM HOSPITAL.EMPLOYEE;
SELECT * FROM [SECURITY].[USER];

SELECT * FROM HOSPITAL.PATIENT;
SELECT * FROM HOSPITAL.ALLOCATION ORDER BY DateOfAssignment DESC;

SELECT * FROM HOSPITAL.CONSULTATION;