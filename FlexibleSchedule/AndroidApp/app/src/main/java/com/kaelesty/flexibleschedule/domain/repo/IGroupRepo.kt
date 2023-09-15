package com.kaelesty.flexibleschedule.domain.repo

import androidx.lifecycle.LiveData
import com.kaelesty.flexibleschedule.domain.entities.Timetable

interface IGroupRepo {

	fun getFullTimetable(): LiveData<Timetable>

	suspend fun updateTimetable()
}