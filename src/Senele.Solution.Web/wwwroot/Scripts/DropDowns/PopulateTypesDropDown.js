Vue.component('v-select', VueSelect.VueSelect);

var categoriesToDisplay = new Vue({
    el: '#typesToDisplay',
    data: {
        options: GetAllTypes()
    },
    methods: {
        changeHandler(type) {

            if (type) {
                

                document.getElementById("ObjectToCreate_TransactionTypeID").value = type.id;

            } else {
                document.getElementById("ObjectToCreate_TransactionTypeID").value = null;
            }
        }
    },
    render: function render(h) {
        return h("v-select", {
            "on": {
                "input": this.changeHandler
            },
            "attrs": {
                "multiple": false,
                "options": this.options,
                "item-value": this.options,
                "item-text": this.options,
                "placeholder": "--- Select Transaction Type ---"
            }
        });
    }
});

function GetAllTypes() {
    let data = [];
   
    window.axios.get('/api/app/transaction-type/transaction-types').then(function (response) {
        for (let i = 0; i < response.data.length; i++) {
            data.push({
                id: response.data[i].transactionTypeID,
                label: response.data[i].transactionTypeName
            });
        }
    });

    return data;
}