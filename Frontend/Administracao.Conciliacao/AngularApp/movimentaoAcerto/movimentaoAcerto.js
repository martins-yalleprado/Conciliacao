angular.module('MartinsApp').controller('MovimentacaoAcerto',

    function ($scope, $http, AppConstants) {

        $scope.getMovimentacaoAcertoPorData: Function (data: string): Observable<MovimentacaoAcerto[]> {
            console.log(`${this._baseURL}/grid/?Data=${data}`);

        return $cope.http
            .get(`${this._baseURL}/grid/?Data=${data}`)
            .map((response: Response) => {
                return <MovimentacaoAcerto[]>response.json();
        })
            .catch(this.handleError);
        }
    }
);