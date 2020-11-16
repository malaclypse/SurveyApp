# API

### /user


* get /user
   * Този ендпойнт връща User според подаден имейл адрес
* post /user
   * Създава нов юзър по подаден имейл

### /user/{userId}/survey

* get /user/{userId}/survey
   * Връща последното активно survey за дадения юзър
* post /user/{userId}/survey
   * Създава ново survey за това user
* delete /user/{userId}/survey/{surveyId}
   * Изтрива survey

### /user/{userId}/survey/{surveyId}/mapping

* get /user/{userId}/survey/{surveyId}/mapping
   * Връща мапингите между текст/категория, които съществуват до момента за този survey
* post /user/{userId}/survey/{surveyId}/mapping
   * Създава нов мапинг
* delete /user/{userId}/survey/{surveyId}/mapping/{mappingId}
   * Изтрива съществуващ мапинг

### /textEntry

* get /textEntry
   * Връща осем от зададените 20 текста на рандъм принцип

### /category

* get /category
   * Връща петте възможни категории

### /user/{userId}/userDetails

* get /user/{userId}/userDetails
   * Връща детайли за юзъра, като ниво на английски и тн.
* post /user/{userId}/userDetails
   * Праща детайлите на юзъра
* put /user/{userId}/userDetails
   * Обновява детайлите на юзъра, при нужда от ъпдейт
* delete /user/{userId}/userDetails
   * Честно казано не знам дали има нужда от изтриване, ама ще видим в процеса на работа :)
