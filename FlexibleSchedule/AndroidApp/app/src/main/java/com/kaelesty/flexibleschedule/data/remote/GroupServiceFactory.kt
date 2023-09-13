package com.kaelesty.flexibleschedule.data.remote

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object GroupServiceFactory {

	private const val URL = "https://eece-193-32-202-124.ngrok-free.app/api/Group/"

	val apiService: GroupService = Retrofit.Builder()
		.baseUrl(URL)
		.addConverterFactory(GsonConverterFactory.create())
		.build()
		.create(GroupService::class.java)
}