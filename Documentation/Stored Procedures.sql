USE HospitalManagementSystem;
GO

CREATE PROCEDURE [SECURITY].SP_LOGIN
	@Email VARCHAR (50),
	@Password VARCHAR (MAX)
AS
	BEGIN
		SELECT Id,Rol,Status,Email FROM [SECURITY].[USER] WHERE Email = @Email AND Password = @Password;
	END
GO

/* RECEPTION */
CREATE PROCEDURE HOSPITAL.SP_SEARCH_PATIENT
	@Data VARCHAR(150)
AS
	BEGIN
		SELECT * FROM HOSPITAL.PATIENT
			WHERE Name = @Data OR
				  LastName = @Data OR
				  MotherLastName = @Data OR
				  CURP = @Data;
	END
GO

CREATE PROCEDURE HOSPITAL.SP_MEDICAL_HISTORY
	@Id INT
AS
	BEGIN
		SELECT * FROM HOSPITAL.CONSULTATION WHERE Patient = @Id
	END
GO

CREATE PROCEDURE HOSPITAL.SP_LOCATE_PATIENT
	@IdPatient					INT
AS
	BEGIN
		IF ( (SELECT Status FROM HOSPITAL.PATIENT WHERE Id = @IdPatient) = 4) -- IF STATUS IS 'ADMITTED'
			SELECT Assgnment, DateOfAssignment, DischargeDate
				FROM HOSPITAL.ALLOCATION
				WHERE Patient = @IdPatient ORDER BY DateOfAssignment;
		ELSE
			SELECT 0;
			
	END
GO


/* RECEPTION / MANAGEMENT */
CREATE PROCEDURE HOSPITAL.SP_PATIENT_ASSIGNMENT
	@Patient			INT,
	@DoctorInCharge		INT,
	@Assgnment			VARCHAR (15),
	@DateOfAssignment	DATETIME
AS
	BEGIN
		INSERT INTO HOSPITAL.ALLOCATION
			VALUES(
				@Patient,
				@DoctorInCharge,
				@Assgnment,
				@DateOfAssignment,
				NULL
			);
	END
GO

CREATE PROCEDURE HOSPITAL.SP_NEW_MEDICAL_CONSULTATION
	@Allocation			INT,
	@Patient			INT,
	@Doctor				INT,
	@ConsultationDate	DATETIME,
	@Symptoms			VARCHAR (MAX),
	@Diagnosis			VARCHAR (MAX),
	@Treatment			VARCHAR (MAX)
AS
	BEGIN
		INSERT INTO HOSPITAL.CONSULTATION
			VALUES(
				@Allocation,
				@Patient,
				@Doctor,
				@ConsultationDate,
				@Symptoms,
				@Diagnosis,
				@Treatment
			)
	END
GO


/* MANAGEMENT */
-- ADDING
CREATE PROCEDURE [SECURITY].SP_ADD_ROL
	@ROL VARCHAR (50)
AS
	BEGIN
		INSERT INTO [SECURITY].ROL VALUES (@ROL);
	END
GO

CREATE PROCEDURE HOSPITAL.SP_ADD_EMPLOYEE
	@Name				VARCHAR (150),
	@LastName			VARCHAR (50),
	@MotherLastName		VARCHAR (50),
	@Gender				CHAR (1),
	@BirthDate			DATE,
	@Age				INT,
	@Email				VARCHAR (50),
	@Phone				CHAR (10),
	@Address			VARCHAR (255),
	@Job				INT
AS
	BEGIN
		INSERT INTO HOSPITAL.EMPLOYEE
			VALUES (
				@Name,
				@LastName,
				@MotherLastName,
				@Gender,
				@BirthDate,
				@Age,
				@Email,
				@Phone,
				@Address,
				@Job,
				1 --STATUS = ACTIVO
			)
	END
GO

CREATE PROCEDURE HOSPITAL.SP_REGISTER_PATIENT
	@CURP				CHAR (18),
	@Name				VARCHAR (150),
	@LastName			VARCHAR (50),
	@MotherLastName		VARCHAR (50),
	@Gender				CHAR (1),
	@BirthDate			DATE,
	@Age				INT,
	@Phone				CHAR (10),
	@Address			VARCHAR (255)
AS
	BEGIN
		INSERT INTO HOSPITAL.PATIENT
			VALUES(
				@CURP,
				@Name,
				@LastName,
				@MotherLastName,
				@Gender,
				@BirthDate,
				@Age,
				@Phone,
				@Address,
				1 --STATUS = ACTIVO
			)
	END
GO

-- UPDATING
CREATE PROCEDURE HOSPITAL.SP_UPDATE_EMPLOYEES
	@Id					INT,
	@Name				VARCHAR (150),
	@LastName			VARCHAR (50),
	@MotherLastName		VARCHAR (50),
	@Gender				CHAR (1),
	@BirthDate			DATE,
	@Age				INT,
	@Email				VARCHAR (50),
	@Phone				CHAR (10),
	@Address			VARCHAR (255),
	@Job				INT,
	@Status				INT
AS
	BEGIN
		UPDATE HOSPITAL.EMPLOYEE
			SET 
				Name = @Name,
				LastName = @LastName,
				MotherLastName = @MotherLastName,
				Gender = @Gender,
				BirthDate = @BirthDate,
				Age = @Age,
				Email = @Email,
				Phone = @Phone,
				Address = @Address,
				Job = @Job,
				Status = @Status
			WHERE
				Id = @Id;
	END
GO

CREATE PROCEDURE HOSPITAL.SP_UPDATE_PATIENT
	@Id					INT,
	@CURP				CHAR (18),
	@Name				VARCHAR (150),
	@LastName			VARCHAR (50),
	@MotherLastName		VARCHAR (50),
	@Gender				CHAR (1),
	@BirthDate			DATE,
	@Age				INT,
	@Phone				CHAR (10),
	@Address			VARCHAR (255),
	@Status				INT
AS
	BEGIN
		UPDATE HOSPITAL.PATIENT
			SET
				CURP = @CURP,
				Name = @Name,
				LastName = @LastName,
				MotherLastName = @MotherLastName,
				Gender = @Gender,
				BirthDate = @BirthDate,
				Age = @Age,
				Phone = @Phone,
				Address = @Address,
				Status = @Status
			WHERE
				Id = @Id;
	END
GO

CREATE PROCEDURE HOSPITAL.SP_PATIENT_DISCHARGE
	@Id				INT
AS
	BEGIN
		UPDATE HOSPITAL.PATIENT
			SET Status = 5 --Patient Discharge
			WHERE Id = @Id;

		UPDATE HOSPITAL.ALLOCATION
			SET DischargeDate = GETDATE ()
			WHERE Patient = @Id
	END
GO

-- REMOVING

CREATE PROCEDURE HOSPITAL.SP_DEAD_PATIENT
	@Id				INT
AS
	BEGIN
		UPDATE HOSPITAL.PATIENT
			SET Status = 6 --DEAD
			WHERE Id = @Id;
	END
GO

CREATE PROCEDURE HOSPITAL.SP_EMPLOYEE_NOT_AVAILABLE
	@Id				INT
AS
	BEGIN
		UPDATE HOSPITAL.EMPLOYEE
			SET Status = 2 --Disabled
			WHERE Id = @Id;
	END
GO

CREATE PROCEDURE HOSPITAL.SP_UNEMPLOYED
	@Id				INT
AS
	BEGIN
		UPDATE HOSPITAL.EMPLOYEE
			SET Status = 3 --Removed
			WHERE Id = @Id;
	END
GO