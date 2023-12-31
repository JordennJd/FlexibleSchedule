package com.kaelesty.flexibleschedule.presentation.fragments.schedule

import android.app.Application
import android.content.Context
import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider

class ScheduleViewModelFactory(private val context: Context, private val application: Application): ViewModelProvider.Factory {

	override fun <T : ViewModel> create(modelClass: Class<T>): T {
		return ScheduleViewModel(context, application) as T
	}
}