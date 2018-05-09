<template>
  <div>
    <el-row type="flex">
      <el-col :span="22" class="ml-3">
        <h1>{{item.departure_city}} <i class="fas fa-arrow-right"></i> {{item.arriving_city}}</h1>
      </el-col>
      <el-col :span="2" v-if="item.canDelete" style="margin-right: 20px;">
        <el-button type="danger" icon="el-icon-delete" @click="dialogVisible=true">Supprimer</el-button>
      </el-col>
    </el-row>


    <el-row type="flex">
      <el-col :span="16" style="margin: 20px;">
        <el-card>
          <ul class="list-group list-group-flush text-left">
            <li class="list-group-item">Départ : <span class="font-weight-bold"> {{item.departure_city}} </span></li>
            <li class="list-group-item">Arrivée : <span class="font-weight-bold">{{item.arriving_city}} </span></li>
            <li class="list-group-item">Date de départ : <span class="font-weight-bold">{{dateFormatter(item.departure_time)}}</span></li>
            <li class="list-group-item">Date d'arrivée : <span class="font-weight-bold">{{dateFormatter(item.arriving_time)}}</span></li>
          </ul>
        </el-card>

        <el-card style="margin-top: 30px;">
          <div class="media">
            <img class="align-self-start mr-3" :src="item.driver_img" alt="Profile image">
            <div class="media-body">
              <a class="mt-0" style="font-size: x-large;" :href="'/users/'+item.driver_id">{{item.driver_firstname}} {{item.driver_name}}</a>
              <el-row type="flex" class="mt-3">
                <el-col :span="12" class="grey">{{item.driver_avg}} / 5 <i class="fas fa-star text-warning"></i></el-col>
                <el-col :span="12" class="grey">{{item.driver_nb_comments}} avis</el-col>
              </el-row>
              <div class="pt-5">
                <ul class="list-group list-flush text-success text-left">
                  <li class="list-group-item"><i class="fas fa-check-circle"></i> Carte d'identité validée</li>
                  <li class="list-group-item"><i class="fas fa-check-circle"></i> Permis de conduire validé</li>
                </ul>
              </div>
            </div>
          </div>
        </el-card>
      </el-col>

      <el-col :span="8" style="margin: 20px;">
        <el-card>
          <p>Prix par personne <span class="price">{{item.price}} €</span></p>
          <el-select v-model="form.nb_seats" clearable placeholder="Nombre de places">
            <el-option
              v-for="nb in parseInt(item.remaining_seats)"
              :key="nb"
              :label="nb+' place'+(nb > 1 ? 's' : '')"
              :value="nb">
            </el-option>
          </el-select>
          <br>
          <button v-if="form.nb_seats !== null && form.nb_seats !== ''" style="margin-top: 30px;width: 80%;" class="btn bg-orange white" @click="book()">Réserver</button>
        </el-card>
      </el-col>
    </el-row>

    <modal-delete :dialog-visible="dialogVisible" section="trip" v-on:clickBtn="deleteHandler" :dialog-text="'Etes-vous sûrs de vouloir supprimer ce trajet ?'"></modal-delete>
  </div>
</template>

<script>

  import moment from 'moment';
  import ModalDelete from './ModalDelete'

  export default
  {
    name: "Trip",
    components: {ModalDelete},
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
          driver_id: 1,
          driver_firstname: "Farah",
          driver_name: "Nedjadi",
          driver_img: "https://loremflickr.com/320/240?lock=1",
          remaining_seats: "3",
          driver_avg: 4,
          driver_nb_comments: 9,
          canDelete: true
        },
        form:
        {
          nb_seats: null
        },
        dialogVisible: false
      }
    },
    methods:
    {
      dateFormatter(date)
      {
        moment.locale('fr');
        return moment(date).format("dddd Do MMMM Y [à] H[h]mm");

      },

      book()
      {
        // TODO : REQ
        console.log(this.form.nb_seats)
      },

      deleteHandler(action)
      {
        if (action === 'Y')
          return this.deleteTrip();

        this.dialogVisible = false;
      },
      deleteTrip()
      {
        console.log("Delete");
        // TODO : REQ
        this.dialogVisible = false;
        this.$router.push('/home');
      }


    }

  }
</script>

<style scoped>

  .price
  {
    font-size: x-large;
    color: green;
  }

  .bg-orange
  {
    background-color: #ff8d33;
  }
</style>