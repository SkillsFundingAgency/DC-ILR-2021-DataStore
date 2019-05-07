

CREATE VIEW [Valid].[LearnerDenorm]
AS
	SELECT
		l.[UKPRN],
		l.[LearnRefNumber],
		l.[PrevLearnRefNumber],		
		l.[PrevUKPRN],
		l.[PMUKPRN],
		l.[CampId],
		l.[ULN],
		l.[FamilyName],
		l.[GivenNames],
		l.[DateOfBirth],
		l.[Ethnicity],
		l.[Sex],
		l.[LLDDHealthProb],
		l.[NINumber],
		l.[PriorAttain],
		l.[Accom],
		l.[ALSCost],
		l.[PlanLearnHours],
		l.[PlanEEPHours],
		l.[MathGrade],
		l.[EngGrade],
		l.[PostcodePrior],
		l.[Postcode],
		l.[AddLine1],
		l.[AddLine2],
		l.[AddLine3],
		l.[AddLine4],
		l.[TelNo],
		l.[Email],
		l.[OTJHours]
		,LSR.LSR1
		,LSR.LSR2
		,LSR.LSR3
		,LSR.LSR4
		,NLM.NLM1
		,NLM.NLM2
		,PPE.PPE1
		,PPE.PPE2
		,EDF.EDF1
		,EDF.EDF2
		,ehc.LearnFAMCode as [EHC]
		,ecf.LearnFAMCode as [ECF]
		,hns.LearnFAMCode as [HNS]
		,dla.LearnFAMCode as [DLA]
		,mcf.LearnFAMCode as [MCF]
		,sen.LearnFAMCode as [SEN]
		,fme.LearnFAMCode as [FME]
		,ProvSpecMon_A.ProvSpecLearnMon AS ProvSpecLearnMon_A	
		,ProvSpecMon_B.ProvSpecLearnMon AS ProvSpecLearnMon_B
	from
		Valid.Learner as l
		left join
		(
			select
				LearnRefNumber,
				UKPRN,
				max([LSR1]) as [LSR1],
				max([LSR2]) as [LSR2],
				max([LSR3]) as [LSR3],
				max([LSR4]) as [LSR4]
			from
				(
					select
						LearnRefNumber,
						UKPRN,
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 1 then LearnFAMCode else null end  as [LSR1],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 2 then LearnFAMCode else null end  as [LSR2],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 3 then LearnFAMCode else null end  as [LSR3],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 4 then LearnFAMCode else null end  as [LSR4]
					from
						Valid.[LearnerFAM]
					where
						[LearnFAMType]='LSR'
				) as [LSRs]
			group by
				LearnRefNumber,
				UKPRN
		) as [LSR]
		on [LSR].LearnRefNumber = l.LearnRefNumber
		AND [LSR].UKPRN = L.UKPRN
		left join
		(
			select
				LearnRefNumber,
				UKPRN,
				max([NLM1]) as [NLM1],
				max([NLM2]) as [NLM2]
			from
				(
					select
						LearnRefNumber,
						UKPRN,
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 1 then LearnFAMCode else null end  as [NLM1],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 2 then LearnFAMCode else null end  as [NLM2]
					from
						Valid.[LearnerFAM]
					where
						[LearnFAMType]='NLM'
				) as [NLMs]
			group by
				LearnRefNumber,
				UKPRN
		) as [NLM]
			on [NLM].LearnRefNumber = l.LearnRefNumber
			AND [NLM].UKPRN = L.UKPRN
		left join
		(
			select
				LearnRefNumber,
				UKPRN,
				max([PPE1]) as [PPE1],
				max([PPE2]) as [PPE2]
			from
				(
					select
						LearnRefNumber,
						UKPRN,
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 1 then LearnFAMCode else null end  as [PPE1],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 2 then LearnFAMCode else null end  as [PPE2]
					from
						Valid.[LearnerFAM]
					where
						[LearnFAMType]='PPE'
				) as [PPEs]
			group by
				LearnRefNumber, [UKPRN]
		) as [PPE]
			on [PPE].LearnRefNumber = l.LearnRefNumber
			AND [PPE].UKPRN = L.UKPRN
		left join
		(
			select
				[LearnRefNumber],
				[UKPRN],
				max([EDF1]) as [EDF1],
				max([EDF2]) as [EDF2]
			from
				(
					select
						[LearnRefNumber],
						[UKPRN],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 1 then LearnFAMCode else null end  as [EDF1],
						case row_number() over (partition by [LearnRefNumber], [UKPRN] order by [LearnRefNumber]) when 2 then LearnFAMCode else null end  as [EDF2]
					from
						[Valid].[LearnerFAM]
					where
						[LearnFAMType]='EDF'
				) as [EDFs]
			group by
				[LearnRefNumber]
				,UKPRN
		) as [EDF]
			on [EDF].[LearnRefNumber]=l.LearnRefNumber
			AND [EDF].UKPRN = L.UKPRN
		left join
			Valid.LearnerFAM as ehc
				on ehc.LearnRefNumber = l.LearnRefNumber
				AND ehc.UKPRN = L.UKPRN
				and ehc.LearnFAMType = 'EHC' 
		left join
			Valid.LearnerFAM as ecf
				on ecf.LearnRefNumber = l.LearnRefNumber
				AND ECF.UKPRN = L.UKPRN
				and ecf.LearnFAMType = 'ECF'
		left join
			Valid.LearnerFAM as hns
				on hns.LearnRefNumber = l.LearnRefNumber
				AND HNS.UKPRN = L.UKPRN
				and hns.LearnFAMType = 'HNS'
		left join
			Valid.LearnerFAM as dla
				on dla.LearnRefNumber = l.LearnRefNumber
				AND DLA.UKPRN = L.UKPRN
				and dla.LearnFAMType = 'DLA'
		left join
			Valid.LearnerFAM as mcf
				on mcf.LearnRefNumber = l.LearnRefNumber
				AND MCF.UKPRN = L.UKPRN
				and mcf.LearnFAMType = 'MCF'
		left join
			Valid.LearnerFAM as sen
				on sen.LearnRefNumber = l.LearnRefNumber
				AND SEN.UKPRN = L.UKPRN
				and sen.LearnFAMType = 'SEN'
		left join
			Valid.LearnerFAM as fme
				on fme.LearnRefNumber = l.LearnRefNumber
				AND FME.UKPRN = L.UKPRN
				and fme.LearnFAMType = 'FME'
		left join Valid.[ProviderSpecLearnerMonitoring] as [ProvSpecMon_A]
			on [ProvSpecMon_A].[LearnRefNumber] = l.LearnRefNumber
			AND [ProvSpecMon_A].UKPRN = L.UKPRN
			and [ProvSpecMon_A].[ProvSpecLearnMonOccur]='A'
		left join Valid.[ProviderSpecLearnerMonitoring] as [ProvSpecMon_B]
			on [ProvSpecMon_B].LearnRefNumber = l.[LearnRefNumber]
			AND [ProvSpecMon_B].UKPRN = L.UKPRN
			and [ProvSpecMon_B].[ProvSpecLearnMonOccur]='B'
