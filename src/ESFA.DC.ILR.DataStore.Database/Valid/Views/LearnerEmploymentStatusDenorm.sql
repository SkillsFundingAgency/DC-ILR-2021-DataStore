

CREATE VIEW [Valid].[LearnerEmploymentStatusDenorm]
AS
	SELECT 
	les.[UKPRN]
	,les.[LearnRefNumber]
	,les.[EmpStat]
	,les.EmpId
	,les.[DateEmpStatApp]
	,les.[AgreeId]	
	,[EmpStatMon_BSI].ESMCode AS ESMCode_BSI
	,[EmpStatMon_EII].ESMCode AS ESMCode_EII
	,[EmpStatMon_LOE].ESMCode AS ESMCode_LOE
	,[EmpStatMon_LOU].ESMCode AS ESMCode_LOU
	,[EmpStatMon_PEI].ESMCode AS ESMCode_PEI
	,[EmpStatMon_SEI].ESMCode AS ESMCode_SEI
	,[EmpStatMon_SEM].ESMCode AS ESMCode_SEM
FROM 
	Valid.[LearnerEmploymentStatus] as les
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_BSI]
		on [EmpStatMon_BSI].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_BSI].UKPRN = LES.UKPRN
		and [EmpStatMon_BSI].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_BSI].[ESMType]='BSI'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_EII]
		on [EmpStatMon_EII].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_EII].UKPRN = LES.UKPRN
		and [EmpStatMon_EII].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_EII].[ESMType]='EII'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_LOE]
		on [EmpStatMon_LOE].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_LOE].UKPRN = LES.UKPRN
		and [EmpStatMon_LOE].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_LOE].[ESMType]='LOE'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_LOU]
		on [EmpStatMon_LOU].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_LOU].UKPRN = LES.UKPRN
		and [EmpStatMon_LOU].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_LOU].[ESMType]='LOU'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_PEI]
		on [EmpStatMon_PEI].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_PEI].UKPRN = LES.UKPRN
		and [EmpStatMon_PEI].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_PEI].[ESMType]='PEI'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_SEI]
		on [EmpStatMon_SEI].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_SEI].UKPRN = LES.UKPRN
		and [EmpStatMon_SEI].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_SEI].[ESMType]='SEI'
	left join Valid.[EmploymentStatusMonitoring] as [EmpStatMon_SEM]
		on [EmpStatMon_SEM].LearnRefNumber=les.LearnRefNumber
		AND [EmpStatMon_SEM].UKPRN = LES.UKPRN
		and [EmpStatMon_SEM].DateEmpStatApp = les.DateEmpStatApp
		and [EmpStatMon_SEM].[ESMType]='SEM'
