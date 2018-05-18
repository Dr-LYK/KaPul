<template>

  <div class="divSection">

    <el-row type="flex">

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
        <div>
          <h2 style="line-height: 50px;">Où allez vous ?</h2>
          <el-form ref="form" :model="form" label-width="0">
            <el-form-item label="">
              <el-col :span="4">
                <i class="fab fa-font-awesome-flag"></i>
              </el-col>
              <el-col :span="16">
                <el-input v-model="form.departure_city" placeholder="Départ"></el-input>
              </el-col>
            </el-form-item>
            <el-form-item label="">
              <el-col :span="4">
                <i class="fab fa-font-awesome-flag"></i>
              </el-col>
              <el-col :span="16">
                <el-input v-model="form.arriving_city" placeholder="Destination"></el-input>
              </el-col>
            </el-form-item>
            <el-form-item >
              <el-col :span="4">
                <i class="far fa-calendar-alt"></i>
              </el-col>
              <el-col :span="16">
                <el-date-picker type="datetime" placeholder="Date" v-model="form.departure_time" style="width: 100%;"></el-date-picker>
              </el-col>
            </el-form-item>
            <el-form-item>
              <el-button type="primary" @click="searchTrip">J'y vais !</el-button>
            </el-form-item>
          </el-form>
        </div>
      </el-col>

    </el-row>
  </div>
</template>

<script>

  import moment from 'moment'

  export default
  {
    name: "Home",
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
        form: {departure_city: "", arriving_city: "", departure_time: ""}
      }
    },

    mounted()
    {
      this.$http.defaults.headers.common['Authorization'] = "Bearer "+  this.$session.get('token');

      this.$http.get('/bestPrices')
      .then(res =>
      {
        this.arrBestPrices = res.data;
      })
      .catch(err =>
      {

      });

      this.$http.get('/nextDepartures')
      .then(res =>
      {
        this.arrNextDepartures = res.data;
      })
      .catch(err =>
      {

      });

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
      },

      searchTrip()
      {
        //console.log(this.form);
        this.$router.push('/trips?from='+this.form.departure_city+'&to='+this.form.arriving_city+'&date='+this.form.departure_time);
      },

    }
  }
</script>

<style scoped>

  .divSection
  {
    padding-top: 64px;
    padding-bottom: 100px;
    width: 100%;
  }
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