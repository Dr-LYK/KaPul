<template>
  <div>

    <el-row type="flex">

      <el-col :span="7" class="bg-blue white" style="margin-left: 20px;">
        <trip-search :form="{from: searchForm.from, to: searchForm.to, date: searchForm.date}"></trip-search>
      </el-col>

      <el-col :span="17" style="margin-left: 20px;margin-right: 20px;">
        <div v-if="arrTrips.length > 0">
          <p style="text-align: right;">
            {{arrTrips.length}}
            <span v-if="arrTrips.length > 1">trajets trouvés</span>
            <span v-else>trajet trouvé</span>
          </p>

          <ul class="list-group">
            <li v-for="item in arrTrips" class="list-group-item list_li bg-LightGrey" @click="showTrip(item.id)">
              <el-row type="flex">
                <el-col :span="6">
                  <el-row>
                    <el-col :span="8"><img :src="item.driver_img" class="list_img_profile"> </el-col>
                    <el-col :span="16"><p class="list_driver">{{item.driver_firstname}}  {{item.driver_name}}</p></el-col>
                  </el-row>

                  <el-row style="margin-top:50px;">
                    <el-col :span="8" class="grey">{{item.driver_avg}} / 5 <i class="fas fa-star text-warning"></i></el-col>
                    <el-col :span="16" class="grey">{{item.driver_nb_comments}} avis</el-col>
                  </el-row>
                </el-col>

                <el-col :span="12" style="border-left:1px solid grey;">
                  <p class="list_date">{{dateFormatter(item.departure_time)}}</p>
                  <p class="list_cities">{{item.departure_city}} <i class="fas fa-arrow-right"></i> {{item.arriving_city}}</p>
                </el-col>

                <el-col :span="6">
                  <p class="list_price">{{item.price}} €</p>
                  <p class="list_nb_remaining_seats grey">
                    <span v-if="item.remaining_seats > 1">{{item.remaining_seats}} places restantes</span>
                    <span v-else class="text-danger">{{item.remaining_seats}} place restante</span>
                  </p>
                </el-col>
              </el-row>
            </li>
          </ul>
        </div>
        <h2 v-else>Aucun résultat.</h2>
      </el-col>

    </el-row>
  </div>
</template>

<script>

  import moment from 'moment'
  import TripSearch from './TripSearch'

  export default
  {
    name: "trips",
    components: {TripSearch},
    data()
    {
      return {
        arrTrips:
        [
          {
            id: "4",
            departure_city: "Paris",
            arriving_city: "Versailles",
            price: "12",
            departure_time: "2018-05-24 00:00:00",
            remaining_seats: "2",
            driver_firstname: "Farah",
            driver_name: "Nedjadi",
            driver_img: "https://loremflickr.com/320/240?lock=1",
            driver_avg: "4",
            driver_nb_comments: "8"
          },
          {
            id: "5", departure_city: "Limoges", arriving_city: "Brest", price: "53", departure_time: "2018-05-30 08:00:00", remaining_seats: "4",
            driver_firstname: "Corentin", driver_name: "Redon", driver_img: "https://loremflickr.com/320/240?lock=1",  driver_avg: "4", driver_nb_comments: "8"
          },
          {
            id: "6", departure_city: "Lyon", arriving_city: "Bordeaux", price: "37", departure_time: "2018-06-02 08:30:00",  remaining_seats: "1",
            driver_firstname: "Vivian", driver_name: "Chaizemartin", driver_img: "https://loremflickr.com/320/240?lock=1", driver_avg: "4", driver_nb_comments: "8"
          }
        ],
        searchForm:
        {
          from : "",
          to: "",
          date: ""
        }
      }
    },

    mounted()
    {
      if (typeof this.$route.query.from !== 'undefined')
        this.searchForm.from = this.$route.query.from;

      if (typeof this.$route.query.to !== 'undefined')
        this.searchForm.to = this.$route.query.to;

      if (typeof this.$route.query.date !== 'undefined')
        this.searchForm.date = this.$route.query.date;

    },

    methods:
    {
      dateFormatter(date)
      {
        moment.locale('fr');
        return moment(date).format("dddd Do MMMM Y [à] H[h]mm");

      },

      showTrip(id)
      {
        this.$router.push("/trips/"+id);
      }
    }
  }
</script>

<style scoped>

  .list_li
  {
    margin-top: 20px;
    cursor: pointer;
  }


  .list_img_profile
  {
    width: 100%;
    height: 100%;
  }

  .list_price
  {
    font-size: 3em;
    color: green;
  }


  .grey
  {
    color: grey;
    font-weight: bold;
  }

  .list_date::first-letter
  {
    text-transform: uppercase;
  }
  .list_date, .list_cities
  {
    font-size: x-large;
  }

  .list_cities
  {
    margin-top: 50px;
  }

  .list_driver
  {
    font-weight: bold;
  }
</style>