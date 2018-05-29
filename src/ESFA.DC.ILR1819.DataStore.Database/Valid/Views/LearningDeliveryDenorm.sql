CREATE VIEW Valid.LearningDeliveryDenorm
AS
SELECT
	ld.[UKPRN]
	,ld.[LearnRefNumber]
	,ld.[LearnAimRef]
	,ld.[AimType]
	,ld.[AimSeqNumber]
	,ld.[LearnStartDate]
	,ld.[OrigLearnStartDate]
	,ld.[LearnPlanEndDate]
	,ld.[FundModel]
	,ld.[ProgType]
	,ld.[FworkCode]
	,ld.[PwayCode]
	,ld.[StdCode]
	,ld.[PartnerUKPRN]
	,ld.[DelLocPostCode]
	,ld.[AddHours]
	,ld.[PriorLearnFundAdj]
	,ld.[OtherFundAdj]
	,ld.[ConRefNumber]
	,ld.[EPAOrgID]
	,ld.[EmpOutcome]
	,ld.[CompStatus]
	,ld.[LearnActEndDate]
	,ld.[WithdrawReason]
	,ld.[Outcome]
	,ld.[AchDate]
	,ld.[OutGrade]
	,ld.[SWSupAimId]
	,HEM.HEM1
	,HEM.HEM2
	,HEM.HEM3
	,HHS.HHS1
	,HHS.HHS2
	,[LDFAM_SOF].LearnDelFAMCode AS [LDFAM_SOF]
	,[LDFAM_EEF].LearnDelFAMCode AS [LDFAM_EEF]
	,[LDFAM_RES].LearnDelFAMCode AS [LDFAM_RES]
	,[LDFAM_ADL].LearnDelFAMCode AS [LDFAM_ADL]
	,[LDFAM_FFI].LearnDelFAMCode AS [LDFAM_FFI]
	,[LDFAM_WPP].LearnDelFAMCode AS [LDFAM_WPP]
	,[LDFAM_POD].LearnDelFAMCode AS [LDFAM_POD]
	,[LDFAM_ASL].LearnDelFAMCode AS [LDFAM_ASL]
	,[LDFAM_FLN].LearnDelFAMCode AS [LDFAM_FLN]
	,[LDFAM_NSA].LearnDelFAMCode AS [LDFAM_NSA]
	,[ProvSpecMon_A].ProvSpecDelMon AS ProvSpecDelMon_A
	,[ProvSpecMon_B].ProvSpecDelMon	AS ProvSpecDelMon_B
	,[ProvSpecMon_C].ProvSpecDelMon	AS ProvSpecDelMon_C
	,[ProvSpecMon_D].ProvSpecDelMon	AS ProvSpecDelMon_D
	,LDM.LDM1
	,LDM.LDM2
	,LDM.LDM3
	,LDM.LDM4

FROM
	Valid.LearningDelivery as ld
	left join
	(
		select
			[UKPRN],
			[LearnRefNumber],
			[AimSeqNumber],
			max([HEM1]) as [HEM1],
			max([HEM2]) as [HEM2],
			max([HEM3]) as [HEM3]
		from
			(
				select
					[UKPRN],
					[LearnRefNumber],
					[AimSeqNumber],
					case row_number() over (partition by LearnRefNumber, AimSeqNumber, [UKPRN] order by LearnRefNumber, AimSeqNumber, [UKPRN]) when 1 then LearnDelFAMCode else null end  as [HEM1],
					case row_number() over (partition by LearnRefNumber, AimSeqNumber, [UKPRN] order by LearnRefNumber, AimSeqNumber, [UKPRN]) when 2 then LearnDelFAMCode else null end  as [HEM2],
					case row_number() over (partition by LearnRefNumber, AimSeqNumber, [UKPRN] order by LearnRefNumber, AimSeqNumber, [UKPRN]) when 3 then LearnDelFAMCode else null end  as [HEM3]
				from
					Valid.[LearningDeliveryFAM]
				where
					[LearnDelFAMType]='HEM'
			) as [HEMs]
		group by
			[LearnRefNumber]
			,[AimSeqNumber]
			,[UKPRN]
	) as [HEM]
	on [HEM].[LearnRefNumber]=ld.[LearnRefNumber]
	and [HEM].[AimSeqNumber]=ld.[AimSeqNumber]
	and [HEM].[UKPRN]=ld.[UKPRN]
	left join
	(
		select
			[UKPRN],
			LearnRefNumber, 
			AimSeqNumber,
			max([HHS1]) as [HHS1],
			max([HHS2]) as [HHS2]
		from
			(
				select
					[UKPRN],
					LearnRefNumber,
					AimSeqNumber,
					case row_number() over (partition by LearnRefNumber, AimSeqNumber, [UKPRN] order by LearnRefNumber, AimSeqNumber, [UKPRN]) when 1 then LearnDelFAMCode else null end  as [HHS1],
					case row_number() over (partition by LearnRefNumber, AimSeqNumber, [UKPRN] order by LearnRefNumber, AimSeqNumber, [UKPRN]) when 2 then LearnDelFAMCode else null end  as [HHS2]
				from
					Valid.[LearningDeliveryFAM]
				where
					[LearnDelFAMType]='HHS'
			) as [HHSs]
		group by
			[LearnRefNumber]
			,[AimSeqNumber]
			,[UKPRN]
	) as [HHS]
	on [HHS].[LearnRefNumber]=ld.[LearnRefNumber]
	and [HHS].AimSeqNumber=ld.AimSeqNumber
	and [HHS].[UKPRN]=ld.[UKPRN]

	LEFT JOIN
		[Valid].[LearningDeliveryFAM] AS [LDFAM_SOF] 
			ON ld.[LearnRefNumber] = [LDFAM_SOF].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_SOF].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_SOF].[UKPRN]
			AND [LDFAM_SOF].[LearnDelFAMType] = 'SOF'
	LEFT JOIN
		[Valid].[LearningDeliveryFAM] AS [LDFAM_EEF] 
			ON ld.[LearnRefNumber] = [LDFAM_EEF].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_EEF].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_EEF].[UKPRN]
			AND [LDFAM_EEF].[LearnDelFAMType] = 'EEF'
	LEFT JOIN
		[Valid].[LearningDeliveryFAM] AS [LDFAM_RES] 
			ON ld.[LearnRefNumber] = [LDFAM_RES].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_RES].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_RES].[UKPRN]
			AND [LDFAM_RES].[LearnDelFAMType] = 'RES'
	LEFT JOIN            
		[Valid].[LearningDeliveryFAM] AS [LDFAM_ADL] 
			ON  ld.[LearnRefNumber] = [LDFAM_ADL].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_ADL].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_ADL].[UKPRN]
			AND [LDFAM_ADL].[LearnDelFAMType] = 'ADL'
	LEFT JOIN
        [Valid].[LearningDeliveryFAM] AS [LDFAM_FFI] 
			ON  ld.[LearnRefNumber] = [LDFAM_FFI].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_FFI].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_FFI].[UKPRN]
			AND [LDFAM_FFI].[LearnDelFAMType] = 'FFI'
	LEFT JOIN 
		[Valid].[LearningDeliveryFAM] AS [LDFAM_WPP] 
			ON ld.[LearnRefNumber] = [LDFAM_WPP].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_WPP].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_WPP].[UKPRN]
			AND [LDFAM_WPP].[LearnDelFAMType] = 'WPP'
	LEFT JOIN 
		[Valid].[LearningDeliveryFAM] AS [LDFAM_POD] 
			ON ld.[LearnRefNumber] = [LDFAM_POD].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_POD].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_POD].[UKPRN]
			AND [LDFAM_POD].[LearnDelFAMType] = 'POD'
	LEFT JOIN 
		[Valid].[LearningDeliveryFAM] AS [LDFAM_ASL] 
			ON ld.[LearnRefNumber] = [LDFAM_ASL].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_ASL].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_ASL].[UKPRN]
			AND [LDFAM_ASL].[LearnDelFAMType] = 'ASL'
	LEFT JOIN 
		[Valid].[LearningDeliveryFAM] AS [LDFAM_FLN] 
			ON ld.[LearnRefNumber] = [LDFAM_FLN].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_FLN].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_FLN].[UKPRN]
			AND [LDFAM_FLN].[LearnDelFAMType] = 'FLN'
	LEFT JOIN 
		[Valid].[LearningDeliveryFAM] AS [LDFAM_NSA] 
			ON ld.[LearnRefNumber] = [LDFAM_NSA].[LearnRefNumber]
			AND ld.[AimSeqNumber] = [LDFAM_NSA].[AimSeqNumber]
			AND ld.[UKPRN] = [LDFAM_NSA].[UKPRN]
			AND [LDFAM_NSA].[LearnDelFAMType] = 'NSA'

	left join Valid.[ProviderSpecDeliveryMonitoring] as [ProvSpecMon_A]
		on [ProvSpecMon_A].[LearnRefNumber]=ld.[LearnRefNumber]
		and [ProvSpecMon_A].[AimSeqNumber]=ld.[AimSeqNumber]
		and [ProvSpecMon_A].[UKPRN]=ld.[UKPRN]
		and [ProvSpecMon_A].[ProvSpecDelMonOccur]='A'

	left join Valid.[ProviderSpecDeliveryMonitoring] as [ProvSpecMon_B]
		on [ProvSpecMon_B].[LearnRefNumber]=ld.[LearnRefNumber]
		and [ProvSpecMon_B].[AimSeqNumber]=ld.[AimSeqNumber]
		and [ProvSpecMon_B].[UKPRN]=ld.[UKPRN]
		and [ProvSpecMon_B].[ProvSpecDelMonOccur]='B'

	left join Valid.[ProviderSpecDeliveryMonitoring] as [ProvSpecMon_C]
		on [ProvSpecMon_C].[LearnRefNumber]=ld.[LearnRefNumber]
		and [ProvSpecMon_C].[AimSeqNumber]=ld.[AimSeqNumber]
		and [ProvSpecMon_C].[UKPRN]=ld.[UKPRN]
		and [ProvSpecMon_C].[ProvSpecDelMonOccur]='C'

	left join Valid.[ProviderSpecDeliveryMonitoring] as [ProvSpecMon_D]
		on [ProvSpecMon_D].[LearnRefNumber]=ld.[LearnRefNumber]
		and [ProvSpecMon_D].[AimSeqNumber]=ld.[AimSeqNumber]
		and [ProvSpecMon_D].[UKPRN]=ld.[UKPRN]
		and [ProvSpecMon_D].[ProvSpecDelMonOccur]='D' 
	left join
	(
		select
			[UKPRN],
			[LearnRefNumber],
			[AimSeqNumber],
			max([LDM1]) as [LDM1],
			max([LDM2]) as [LDM2],
			max([LDM3]) as [LDM3],
			max([LDM4]) as [LDM4]
		from
		(
			select
				[UKPRN],
				[LearnRefNumber],
				[AimSeqNumber],
				case row_number() over (partition by [LearnRefNumber], AimSeqNumber, [UKPRN] order by [LearnRefNumber], AimSeqNumber, [UKPRN]) when 1 then LearnDelFAMCode else null end  as [LDM1],
				case row_number() over (partition by [LearnRefNumber], AimSeqNumber, [UKPRN] order by [LearnRefNumber], AimSeqNumber, [UKPRN]) when 2 then LearnDelFAMCode else null end  as [LDM2],
				case row_number() over (partition by [LearnRefNumber], AimSeqNumber, [UKPRN] order by [LearnRefNumber], AimSeqNumber, [UKPRN]) when 3 then LearnDelFAMCode else null end  as [LDM3],
				case row_number() over (partition by [LearnRefNumber], AimSeqNumber, [UKPRN] order by [LearnRefNumber], AimSeqNumber, [UKPRN]) when 4 then LearnDelFAMCode else null end  as [LDM4]
			from
				[Valid].[LearningDeliveryFAM]
			where
				[LearnDelFAMType]='LDM'
		) as [LDMs]
		group by
			[UKPRN],
			[LearnRefNumber],
			[AimSeqNumber]
	) as [LDM]
	on [LDM].[LearnRefNumber]=ld.[LearnRefNumber]
	and LDM.AimSeqNumber = ld.AimSeqNumber
	and LDM.[UKPRN] = ld.[UKPRN]
