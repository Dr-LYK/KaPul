<template>
  <div>
    <el-row type="flex" style="margin:20px;">
      <el-col :span="8">
        <el-card class="bg-LightGrey" style="margin-top:50px;">
          <h2>Vérifications</h2>
          <ul class="list-group list-flush text-success text-left">
            <li class="list-group-item"><i class="fas fa-check-circle"></i> Carte d'identité validée</li>
            <li class="list-group-item"><i class="fas fa-check-circle"></i> Permis de conduire validé</li>
          </ul>
        </el-card>

        <el-card class="mt-5 bg-LightGrey">
          <div class="d-flex justify-content-around">
            <h2 class="w-100">Véhicules</h2>
            <i class="fas fa-plus-circle btn_add" @click="dialogVisibleAddCar=true"></i>
          </div>

            <ul class="list-group">
              <li v-for="car in item.cars" :key="car.id" class="list-group-item">
                <el-row type="flex">
                  <el-col :span="10" class="text-left">{{car.model}}</el-col>
                  <el-col :span="10" class="text-right text-capitalize">{{car.color}}</el-col>
                  <el-col v-if="item.canEdit" :span="4">
                    <el-button type="danger" icon="el-icon-delete" circle @click="dialogVisibleDeleteCar=true"></el-button>
                  </el-col>
                </el-row>
              </li>
            </ul>
        </el-card>
      </el-col>

      <el-col :span="16" style="margin-left: 20px;">

        <el-button type="danger" icon="el-icon-delete" style="float:right" @click="dialogVisibleDeleteProfile=true">Supprimer</el-button>
        <el-button type="warning" icon="el-icon-edit" style="float:right" class="mr-2" @click="dialogVisibleEditProfile=true">Modifier</el-button>
        <br>

        <el-card style="margin-top: 30px;" class="bg-LightGrey">
          <div class="media">
            <img class="align-self-start mr-3" width="200" :src="item.img" alt="Profile image">
            <div class="media-body">
              <h5 class="mt-0" style="font-size: x-large;">{{item.firstname}} {{item.name}}</h5>
              <p>Membre depuis {{dateRegistrationFormatter(item.registration_time)}}</p>

              <el-row type="flex" class="mt-5">
                <el-col :span="12" class="grey">{{item.rate_avg}} / 5 <i class="fas fa-star text-warning"></i></el-col>
                <el-col :span="12" class="grey">{{item.comments.length}} avis</el-col>
              </el-row>
            </div>
          </div>
        </el-card>

        <el-button type="primary" @click="dialogVisibleAddComment=true" class="mt-5">Laisser un commentaire</el-button>
        <br>

        <!-- LIST COMMENTS BEGIN -->
        <ul class="list-group mt-5" >
          <li class="list-group-item bg-LightGrey" v-for="commentEl in item.comments" :key="commentEl.id">
            <el-row type="flex">
              <el-col :span="4"><img :src="commentEl.user_img" class="w-100" height="100px"></el-col>
              <el-col :span="4" style="line-height: 100px;text-align: center;">
                <a style="display: inline-block; vertical-align: center;" :href="'/users/'+commentEl.user_id">{{commentEl.user_firstname}} {{commentEl.user_name}}</a></el-col>
              <el-col :span="16" style="border-left:1px solid black;">
                <h3>{{arrAppreciations[commentEl.rate]}}</h3>
                <p class="grey">{{commentEl.comment}}</p>
              </el-col>
            </el-row>
          </li>
        </ul>
        <!-- LIST COMMENTS END -->
      </el-col>
    </el-row>

    <modal-delete dialog-text="Etes-vous sûr de vouloir supprimer votre profil ?" :section="'profile'" :dialog-visible="dialogVisibleDeleteProfile" v-on:clickBtn="deleteHandler"></modal-delete>

    <modal-delete dialog-text="Etes-vous sûr de vouloir supprimer ce véhicule ?" :section="'car'" :dialog-visible="dialogVisibleDeleteCar" v-on:clickBtn="deleteHandler"></modal-delete>

    <!--- ADD COMMENT BEGIN -->
    <el-dialog
      title="Ajout d'un commentaire"
      :visible.sync="dialogVisibleAddComment"
      width="30%"
      center>

      <el-form>
        <el-form-item label="Note">
          <el-select v-model="comment.rate" clearable placeholder="Choisir une appréciation">
            <el-option
              v-for="(val, index) in arrAppreciations"
              :key="val"
              :label="val"
              :value="index">
            </el-option>
          </el-select>
        </el-form-item>

        <el-form-item label="Commentaire">
          <el-input type="textarea" v-model="comment.comment" placeholder="Ecrivez un commentaire.."></el-input>
        </el-form-item>
      </el-form>

      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisibleAddComment=false">Fermer</el-button>
        <el-button type="primary" @click="sendComment">Commenter</el-button>
      </span>
    </el-dialog>
    <!-- ADD COMMENT END -->

    <!-- EDIT PROFILE BEGIN -->
    <el-dialog
      title="Modification du profil"
      :visible.sync="dialogVisibleEditProfile"
      width="30%"
      center>

      <el-form>
        <el-form-item label="Prénom">
          <el-input type="text" v-model="item.firstname"></el-input>
        </el-form-item>

        <el-form-item label="Nom">
          <el-input type="text" v-model="item.name"></el-input>
        </el-form-item>

        <el-form-item label="Email">
          <el-input type="text" v-model="item.email"></el-input>
        </el-form-item>

      </el-form>

      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisibleEditProfile=false">Fermer</el-button>
        <el-button type="primary" @click="updateProfile">Modifier</el-button>
      </span>
    </el-dialog>
    <!-- EDIT PROFILE END -->


    <!-- ADD CAR BEGIN -->
    <el-dialog
      title="Ajout d'un nouveau véhicule"
      :visible.sync="dialogVisibleAddCar"
      width="30%"
      center>

      <el-form>
        <el-form-item label="Modèle">
          <el-input type="text" v-model="newCar.model"></el-input>
        </el-form-item>

        <el-form-item label="Couleur">
          <el-input type="text" v-model="newCar.color"></el-input>
        </el-form-item>

        <el-form-item label="Immatriculation">
          <el-input type="text" v-model="newCar.registration"></el-input>
        </el-form-item>

      </el-form>

      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisibleAddCar=false">Fermer</el-button>
        <el-button type="primary" @click="addCar">Ajouter</el-button>
      </span>
    </el-dialog>
    <!-- ADD CAR END -->




  </div>
</template>

<script>

  import ModalDelete from './ModalDelete'
  import moment from 'moment'

  export default
  {
    components: {ModalDelete},
    data: function()
    {
      return {
        item:
        {
          id: 1,
          firstname: "Jack",
          name: "Loaz",
          email: "jack@gmail.com",
          registration_time: "2018-04-01 12:00:00",
          img: "https://loremflickr.com/320/240?lock=1",
          cars:
          [
            {
              id: 1,
              model: "Opel Astra",
              color: "rouge"
            },
            {
              id: 2,
              model: "Porsche 911 GTS2",
              color: "noire"
            }
          ],
          canComment: true,
          canEdit: true,
          canDelete: true,
          rate_avg: 4,
          comments:
          [
            {
              'id': 1,
              'user_id': 1,
              'user_firstname': "John",
              "user_name": "Wallas",
              "user_img": "https://loremflickr.com/320/240?lock=1",
              "rate": 4,
              "comment": "Well, it was ok."
            }
          ],
        },

        comment:
        {
          rate: null,
          comment: ""
        },

        newCar:
        {
          model: "",
          color: "",
          registration: ""
        },

        arrAppreciations:['A éviter', 'Décevant', "Bof", "Bien", "Très bien", "Parfait"],
        dialogVisibleDeleteProfile: false,
        dialogVisibleDeleteCar: false,
        dialogVisibleAddComment: false,
        dialogVisibleEditProfile: false,
        dialogVisibleAddCar: false
      }
    },
    methods:
    {
      dateRegistrationFormatter(date)
      {
        moment.locale('fr');
        return moment(date).fromNow(true);
      },
      deleteHandler(action, section)
      {
        if (section === 'profile')
        {
          if (action === 'Y')
            return this.deleteProfile();

          this.dialogVisibleDeleteProfile = false;
        }
        else if (section === 'car')
        {
          if (action === 'Y')
            return this.deleteCar();

          this.dialogVisibleDeleteCar = false;
        }
      },

      sendComment()
      {
        // TODO : REQ
        console.log("Send comment");
        this.dialogVisibleAddComment = false;
      },

      updateProfile()
      {
        console.log("Update profile");
        this.dialogVisibleEditProfile = false;
      },

      deleteProfile()
      {
        console.log('Delete profile');
        // TODO : REQ
        this.dialogVisibleDeleteProfile = false;
      },

      addCar()
      {
        // TODO: REQ
        console.log("Add car");
        this.dialogVisibleAddCar = false;
      },

      deleteCar()
      {
        console.log("Delete car");
        this.dialogVisibleDeleteCar = false;
        // TODO : REQ
      }
    }
  }
</script>

<style scoped>
  .btn_add
  {
    font-size: xx-large;
    cursor: pointer;
  }

</style>