<template>
    <div class="row">
        <div class="col-sm-8 offset-sm-2">
            <slot name="header"></slot>
            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th v-for="item in tableProps">{{item}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="obj in list">
                        <td v-for="pr in objProps">{{obj[pr]}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            maxSize: 5
        };
    },
    props:{
        list:{
            type:Array,
            required:true
        },
        objProps:{
            type:Array,
            required:true
        },
        tableProps:{
            type:Array,
            required:true
        }
    }
}
</script>

