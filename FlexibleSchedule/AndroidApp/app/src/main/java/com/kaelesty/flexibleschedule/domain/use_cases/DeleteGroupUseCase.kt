package com.kaelesty.flexibleschedule.domain.use_cases

import com.kaelesty.flexibleschedule.domain.entities.UserGroup
import com.kaelesty.flexibleschedule.domain.repo.IGroupRepo

class DeleteGroupUseCase(private val repo: IGroupRepo) {

	suspend fun deleteGroup(userGroup: UserGroup) = repo.deleteGroup(userGroup)
}