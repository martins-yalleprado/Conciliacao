angular.module('MartinsApp').controller('GestaoCarga',


    function ($scope, $http,  DataService, ModuloService, LocalStorageService) {
        $scope.currentUser = [];
        $scope.selectedMov = undefined;
        $scope.movimentos = undefined;
        $scope.menu = LocalStorageService.getMenu();
        var vm = this;
        // ModuloService.atualizaMenu('Movimentos de cobrança e contábil');

        this.$onInit = function () {
            const today = new Date();
            const dd = today.getDate();
            const mm = today.getMonth() + 1;
            const yyyy = today.getFullYear();
            const dataReferencia = yyyy + '-' + mm + '-' + dd;
            $scope.types = {
                "TIT": true,
                "CTB": true,
                "AGI": true
            }
            vm.getChargeManagement(dataReferencia, { "TIT": true, "AGI": true, "CTB": true });

            /*Tradução datePicker*/
            DataService.TraduzData($scope);
        }

        $scope.carregaDetalhes = function (movimento) {
            $scope.selectedMov = movimento;
            if ($scope.selectedMov.tipo === 'TIT') {
                $scope.carregaDetalhesTitulo($scope.selectedMov.codGestaoCarga);
            }
        }

        $scope.carregaDetalhesTitulo = function (codigo) {
            $http.get(LocalStorageService.getUrlBack() + '/api/MovimentoTitulo/' + codigo)
                .then(function (ResData) {
                    $scope.movimentos = ResData.data.Data;
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                    }
                    else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                    }
                });
        }

        $scope.searchChargeManagement = function (dataref, tipo) {
            debugger;
            if (!(dataref === undefined) && !(dataref === "")) {
                if (!(tipo === undefined) && (!(tipo.AGI === false) || !(tipo.CTB === false) || !(tipo.TIT === false))) {
                    const dateFormated = vm.formataData(dataref);
                    vm.getChargeManagement(dateFormated, tipo);
                }
                else {
                    swal({ title: 'Atenção', text: 'Selecione pelo menos um tipo!', type: 'info', confirmButtonText: 'Ok' });
                }
            } else {
                swal({ title: 'Atenção', text: 'Obrigatório informar uma data!', type: 'info', confirmButtonText: 'Ok' });
            }
        }

        vm.getChargeManagement = function (dataref, tipo) {

            let lista = '';

            if (tipo.AGI) lista += 'AGI,';
            if (tipo.CTB) lista += 'CTB,';
            if (tipo.TIT) lista += 'TIT';


            const data = {
                dataref: dataref,
                tipo: lista
            };
            debugger;
            $http.get(LocalStorageService.getUrlBack() + '/api/GestaoCarga', { params: data })
                .then(function (ResData) {
                    $scope.data = ResData.data.Data;
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                    }
                    else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                    }
                });
        }

        vm.formataData = function (dataref) {
            if (!(dataref === undefined)) {
                const parts = dataref.split("/");
                const day = parseInt(parts[0]);
                const month = parseInt(parts[1]);
                const year = parseInt(parts[2]);

                const dateFormated = year + '-' + month + '-' + day;
                return dateFormated;
            }

        }

        $scope.removerVersao = function (id) {
            if (!id) {
                swal({ title: 'Erro', text: 'Não foi possível prosseguir, id inexistente!', type: 'error', confirmButtonText: 'Ok' });
            } else {
                swal({
                    title: 'Atenção',
                    text: 'Deseja remover a versão?',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    cancelButtonText: 'Cancelar',
                    confirmButtonText: 'Sim'
                }).then((result) => {
                    if (result.value) {
                        $http.delete(LocalStorageService.getUrlBack() + '/api/GestaoCarga?id=' + id)
                            .then(function (resultado) {
                                this.data = resultado.data.Data;
                                swal(
                                    'Feito!',
                                    'A versão foi removida com sucesso.',
                                    'success'
                                );
                                var data = $scope.dataRef.value;
                                var tipo = $scope.types;
                                const dateFormated = vm.formataData(data);
                                vm.getChargeManagement(dateFormated, tipo);
                            })
                            .catch(function (resultado) {
                                if (resultado.data.Message !== undefined) {
                                    swal({ title: 'Erro', text: resultado.data.Message, type: 'error', confirmButtonText: 'Ok' });
                                }
                                else {
                                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                                }
                            });
                    }
                });
            }
        }

        $scope.mudarVersao = function (objeto) {
            this.objeto = objeto;

            swal({
                title: 'Atenção',
                text: 'Deseja alterar a versão?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancelar',
                confirmButtonText: 'Sim'
            }).then((result) => {
                if (result.value) {
                    $http.put(LocalStorageService.getUrlBack() + '/api/GestaoCarga', objeto)
                        .then(function (resultado) {
                            this.data = resultado.data.Data;
                            swal(
                                'Feito!',
                                'A versão foi alterada.',
                                'success'
                            );
                            var data = $scope.dataRef.value;
                            var tipo = $scope.types;
                            const dateFormated = vm.formataData(data);
                            vm.getChargeManagement(dateFormated, tipo);

                        })
                        .catch(function (resultado) {
                            if (resultado.data.Message !== undefined) {
                                swal({ title: 'Erro', text: resultado.data.Message, type: 'error', confirmButtonText: 'Ok' });
                            }
                            else {
                                swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                            }
                        });
                }
            });
        }

        $scope.gerarLote = function (dataref, tipo) {
            if (!tipo || !dataref) {
                swal({ title: 'Atenção', text: 'Obrigatório informar data e tipo!', type: 'info', confirmButtonText: 'Ok' });
            } else {
              
                const dataformatada = vm.formataData(dataref);

                let lista = '';

                if (tipo.AGI) lista += 'AGI,';
                if (tipo.CTB) lista += 'CTB,';
                if (tipo.TIT) lista += 'TIT';

                const dados = {
                    dataref: dataformatada,
                    tipo: lista,
                    codUnidade: 0,
                    codConta: 0
                };

                swal({
                    title: 'Atenção',
                    text: 'Deseja gerar lote?',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    cancelButtonText: 'Cancelar',
                    confirmButtonText: 'Sim'
                }).then((result) => {
                    if (result.value) {

                        $http.post(LocalStorageService.getUrlBack() + '/api/GestaoCarga?' + 'dataref=' + dados.dataref + '&tipo=' + dados.tipo +
                            '&codUnidade=0' + '&codConta=0', dados)
                            .then(function (objeto) {
                                this.data = objeto.data.Data;
                                swal(
                                    'Feito!',
                                    'A versão foi alterada.',
                                    'success'
                                );
                                var data = $scope.dataRef.value;
                                var tipo = $scope.types;
                                const dateFormated = vm.formataData(data);
                                vm.getChargeManagement(dateFormated, tipo);
                            })
                            .catch(function (objeto) {
                                if (objeto.data.Message !== undefined) {
                                    swal({ title: 'Erro', text: objeto.data.Message, type: 'error', confirmButtonText: 'Ok' });
                                }
                                else {
                                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                                }
                            });
                    }
                });
            }
        }

        
    });




