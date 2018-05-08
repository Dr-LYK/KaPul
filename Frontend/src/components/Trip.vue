<template>
  <div>
    <h1>{{item.departure_city}} <i class="fas fa-arrow-right"></i> {{item.arriving_city}}</h1>

    <el-row type="flex">
      <el-col :span="16">

        <el-card>
          <ul class="list-group">
            <li>Départ {{item.departure_city}} </li>
            <li>Arrivée {{item.arriving_city}} </li>
            <li>Date de départ {{dateFormatter(item.departure_time)}}</li>
            <li>Date d'arrivée {{dateFormatter(item.arriving_time)}}</li>
          </ul>
        </el-card>

        <el-card>

        </el-card>
      </el-col>

      <el-col :span="8">

      </el-col>
    </el-row>
  </div>
</template>

<script>
  export default
  {
    name: "Trip",
    data()
    {
      return {
        item:
        {
          id: "4",
          departure_city: "Paris",
          arriving_city: "Versailles",
          price: "12",
          departure_time: "2018-05-24 00:00:00",
          arriving_time: "2018-05-24 02:30:00",
          driver_firstname: "Farah",
          driver_name: "Nedjadi",
          driver_img: "https://loremflickr.com/320/240?lock=1"
        }
      }
    },
    methods:
    {
      dateFormatter(date)
      {
        moment.locale('fr');
        return moment(date).format("dddd Do MMMM Y [à] H[h]mm");

      },
    }

  }
</script>

<style scoped>

</style>