package com.kaelesty.flexibleschedule.data.entities.dtos

import com.kaelesty.flexibleschedule.domain.entities.Timetable

data class GroupDto(
	val code: String,
	val timetable: Timetable
)