<template>
  <div class="home" style="margin-top: 20px;">

    <el-col type="flex">

      <el-col :span="16" style="margin-left: 20px;">

        <h2 style="text-align: left;">Nos meilleurs tarifs</h2>

        <el-row type="flex" justify="space-around">

          <!-- CARD BEST PRICES -->
          <el-col :span="7" v-for="item in arrBestPrices" :key="item.id">
            <div @click="showTrip(item.id)">
              <el-card class="cardBestPrices bg-LightGrey" shadow="hover" >
                <el-col :span="12">
                  <p class="cardBestPrices-from">{{item.departure_city}}</p>
                  <p class="cardBestPrices-to">{{item.arriving_city}}</p>
                </el-col>
                <el-col :span="12">
                  <p class="cardBestPrices-price">{{item.price}} €</p>
                </el-col>
              </el-card>
            </div>
          </el-col>

        </el-row>

        <h2 style="text-align: left;margin-top: 50px;">Prochains départs</h2>

        <el-row type="flex" justify="space-around">
          <!-- CARD NEXT DEPARTURES -->
          <el-col :span="7" v-for="item in arrNextDepartures" :key="item.id" >
            <div @click="showTrip(item.id)">
              <el-card class="cardNextDepartures bg-LightGrey" shadow="hover" >
                <div style="border-bottom: 1px solid grey;">
                  <span>{{item.driver_firstname}} {{item.driver_name}}</span>
                </div>
                <div>
                  <p style="float: right;" class="cardNextDepartures-date">{{dateFormatter(item.departure_time)}}</p>
                  <el-col :span="18">
                    <p class="cardNextDepartures-cities">{{item.departure_city}} - {{item.arriving_city}}</p>
                  </el-col>
                  <el-col :span="6">
                    <p class="cardNextDepartures-price">{{item.price}} €</p>
                  </el-col>
                </div>
              </el-card>
              </div>
            </el-col>
          </el-row>
      </el-col>

      <el-col :span="7" class="bg-blue white" style="margin-right: 20px;">
        <trip-search :form="{from: '', to: '', date: ''}"></trip-search>
      </el-col>

    </el-col>
  </div>
</template>

<script>

  import TripSearch from './TripSearch'
  import moment from 'moment'

  export default
  {
    name: "Home",
    components: {TripSearch},
    data()
    {
      return {
        arrBestPrices:
        [
          {id: "1", departure_city: "Paris", arriving_city: "Orléans", price: "25"},
          {id: "2", departure_city: "Lille", arriving_city: "Nantes", price: "31"},
          {id: "3", departure_city: "Lyon", arriving_city: "Toulouse", price: "17"}
        ],
        arrNextDepartures:
        [
          {
            id: "4",
            departure_city: "Paris",
            arriving_city: "Versailles",
            price: "12",
            departure_time: "2018-05-24 00:00:00",
            driver_firstname: "Farah",
            driver_name: "Nedjadi",
            driver_img: "https://loremflickr.com/320/240?lock=1"
          },
          {id: "5", departure_city: "Limoges", arriving_city: "Brest", price: "53", departure_time: "2018-05-30 08:00:00", driver_firstname: "Corentin",
            driver_name: "Redon", driver_img: "https://loremflickr.com/320/240?lock=1"},
          {id: "6", departure_city: "Lyon", arriving_city: "Bordeaux", price: "37", departure_time: "2018-06-02 08:30:00", driver_firstname: "Vivian",
            driver_name: "Chaizemartin", driver_img: "https://loremflickr.com/320/240?lock=1"}
        ],
        form: {from: "", to: "", date: ""}
      }
    },


    methods:
    {
      showTrip(id)
      {
        console.log(id);
        this.$router.push("/trips/"+id);
      },

      dateFormatter(date)
      {
        moment.locale("fr");
        return moment(date).format("Do MMM [à] H[h]mm")
      }

    }
  }
</script>

<style scoped>



  .cardBestPrices, .cardNextDepartures
  {
    cursor: pointer;
  }
  .cardBestPrices p
  {

  }
  .cardBestPrices-price
  {
    font-size: xx-large;
    color: green;
  }

  .cardNextDepartures-price
  {
    font-size: large;
    color: green;
  }

  .cardNextDepartures-date
  {
    padding-bottom: 0;
    color: #073863;
  }

</style>